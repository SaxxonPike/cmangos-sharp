using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using MangosSharp.Core;
using MangosSharp.Core.Security;
using MangosSharp.Data.Entities.CharacterDatabase;
using MangosSharp.Data.Entities.RealmDatabase;
using MangosSharp.Server.Core.Enums;
using MangosSharp.Server.Core.Messages;
using MangosSharp.Server.Core.Services;
using MangosSharp.Server.Core.Sockets;
using MangosSharp.Server.World.Enums;
using MangosSharp.Server.World.Presence;
using Microsoft.Extensions.Logging;

namespace MangosSharp.Server.World.Messaging;

public class WorldPacketHandler : PacketHandler<WorldOpcode, SocketStream>
{
    private readonly IAuthService _authService;
    private readonly IDatabase _database;
    private readonly IBuildInfoService _buildInfoService;
    private readonly ILogger _logger;
    private readonly IWorldPacketSender _sender;
    private readonly IAccountService _accountService;
    private readonly IUniverse _universe;

    public WorldPacketHandler(IAuthService authService, IDatabase database, IBuildInfoService buildInfoService,
        ILogger logger, IWorldPacketSender sender, IAccountService accountService, IUniverse universe)
    {
        _authService = authService;
        _database = database;
        _buildInfoService = buildInfoService;
        _logger = logger;
        _sender = sender;
        _accountService = accountService;
        _universe = universe;
    }

    private static AuthState GetState(SocketStream stream) =>
        stream.GetMetadata<AuthState>(nameof(AuthState));

    private static void SetState(SocketStream stream, AuthState state) =>
        stream.SetMetadata(nameof(AuthState), state);

    protected override int ReadOpcode(SocketStream stream) =>
        stream.Reader.ReadInt32();

    protected override IReadOnlyDictionary<WorldOpcode, OpcodeHandler<WorldOpcode, SocketStream>> GetHandlers()
    {
        // TODO: fill in these packets

        return new Dictionary<WorldOpcode, OpcodeHandler<WorldOpcode, SocketStream>>
        {
            { WorldOpcode.CMSG_AUTH_SESSION, Handle_CMSG_AUTH_SESSION },
            { WorldOpcode.CMSG_CHAR_ENUM, Handle_CMSG_CHAR_ENUM }
        };
    }

    private bool Handle_CMSG_CHAR_ENUM(WorldOpcode opcode, SocketStream stream, CancellationToken cancel)
    {
        var state = GetState(stream);

        const uint currentSlot = (uint)PetSaveMode.PET_SAVE_AS_CURRENT;
        var accountId = (uint)state.AccountId;

        // var characters = _database.UseCharacter(db => (from character in db.Characters
        //     join guildMember in db.GuildMembers on character.Guid equals guildMember.Guid into ownedGuilds
        //     join pet in db.CharacterPets on character.Guid equals pet.Owner into ownedPets
        //     from ownedPet in ownedPets.DefaultIfEmpty()
        //     from ownedGuild in ownedGuilds.DefaultIfEmpty()
        //     where character.Account == accountId
        //     where ownedPet.Slot == currentSlot
        //     select new
        //     {
        //         character.Guid, character.Name, character.Race, character.Class, character.Gender,
        //         character.PlayerBytes, character.PlayerBytes2, CharLevel = character.Level, character.Zone,
        //         character.Map, character.PositionX, character.PositionY, character.PositionZ, Guild = ownedGuild,
        //         character.PlayerFlags, character.AtLogin, Pet = ownedPet, character.EquipmentCache
        //     }).ToList());

        var characters = _database.UseCharacter(db =>
        {
            var chars = db.Characters.Where(x => x.Account == accountId).ToList();
            var charIds = chars.Select(x => x.Guid).ToList();
            var guilds = db.GuildMembers.Where(x => charIds.Contains(x.Guid)).ToList();
            var pets = db.CharacterPets.Where(x => charIds.Contains(x.Owner)).ToList();
            return chars.Select(character =>
            {
                var guild = guilds.FirstOrDefault(x => x.Guid == character.Guid);
                var pet = pets.FirstOrDefault(x => x.Owner == character.Guid && x.Slot == currentSlot);
                return new
                {
                    character.Guid, character.Name, character.Race, character.Class, character.Gender,
                    character.PlayerBytes, character.PlayerBytes2, CharLevel = character.Level, character.Zone,
                    character.Map, character.PositionX, character.PositionY, character.PositionZ,
                    Guild = guild, character.PlayerFlags, character.AtLogin, Pet = pet, character.EquipmentCache
                };
            });
        });

        var characterItems = _database.UseWorld(db2 =>
        {
            var itemEntries = characters
                .Where(c => !string.IsNullOrWhiteSpace(c.EquipmentCache))
                .SelectMany(c => c.EquipmentCache.Split(' '))
                .Select(uint.Parse)
                .Distinct()
                .ToList();

            return db2.ItemTemplates
                .Where(x => itemEntries.Contains(x.Entry))
                .ToDictionary(x => x.Entry, x => x);
        });

        _sender.Send(stream, WorldOpcode.SMSG_CHAR_ENUM, writer =>
        {
            foreach (var character in characters)
            {
                _logger.LogTrace("Build enum data for char guid {} from account {}. ", character.Guid, accountId);

                writer.Write(new ObjectGuid(HighGuid.PLAYER, unchecked((int)character.Guid)));
                writer.WriteNullTerminatedString(character.Name);
                writer.Write(character.Race);
                writer.Write(character.Class);
                writer.Write(character.Gender);
                writer.Write(character.PlayerBytes);
                writer.Write((byte)(character.PlayerBytes2 & 0xFF));
                writer.Write(character.CharLevel);
                writer.Write(character.Zone);
                writer.Write(character.Map);
                writer.Write(character.PositionX);
                writer.Write(character.PositionY);
                writer.Write(character.PositionZ);
                writer.Write(character.Guild?.Guildid ?? 0);

                var charFlags = (CharacterFlags)0;
                var playerFlags = unchecked((PlayerFlags)character.PlayerFlags);
                var atLoginFlags = unchecked((AtLoginFlags)character.AtLogin);

                if (playerFlags.HasFlag(PlayerFlags.HIDE_HELM))
                    charFlags |= CharacterFlags.HIDE_HELM;
                if (playerFlags.HasFlag(PlayerFlags.HIDE_CLOAK))
                    charFlags |= CharacterFlags.HIDE_CLOAK;
                if (playerFlags.HasFlag(PlayerFlags.GHOST))
                    charFlags |= CharacterFlags.GHOST;
                if (atLoginFlags.HasFlag(AtLoginFlags.AT_LOGIN_RENAME))
                    charFlags |= CharacterFlags.RENAME;

                writer.Write((int)charFlags);
                writer.Write((byte)((atLoginFlags & AtLoginFlags.AT_LOGIN_FIRST) != 0 ? 1 : 0));

                var charClass = (Classes)character.Class;

                // Pets info
                var petEntry = character.Pet?.Entry ?? 0;
                uint petDisplayId = 0;
                uint petLevel = 0;
                uint petFamily = 0;

                // show pet at selection character in character list only for non-ghost character
                if (petEntry != default &&
                    !playerFlags.HasFlag(PlayerFlags.GHOST) &&
                    charClass is Classes.CLASS_WARLOCK or Classes.CLASS_HUNTER)
                {
                    var template = _database.UseWorld(db2 =>
                    {
                        return db2.CreatureTemplates.FirstOrDefault(x => x.Entry == petEntry);
                    });

                    if (template != default)
                    {
                        petDisplayId = character.Pet?.Modelid ?? 0;
                        petLevel = character.Pet?.Level ?? 0;
                        petFamily = unchecked((uint)(template.Family));
                    }
                }

                writer.Write(petDisplayId);
                writer.Write(petLevel);
                writer.Write(petFamily);

                var slots = character.EquipmentCache
                    .Split(' ')
                    .Select(uint.Parse)
                    .ToList();

                for (var slot = 0; slot < (int)EquipmentSlot.INVENTORY_SLOT_BAG_1; slot++)
                {
                    var entry = slots[slot * 2]; // entry, perm ench., temp ench.
                    if (characterItems.TryGetValue(entry, out var template))
                    {
                        writer.Write(template.Displayid);
                        writer.Write(template.InventoryType);
                    }
                    else
                    {
                        writer.Write(0);
                        writer.Write((byte)0);
                    }
                }
            }
        });
        
        return true;
    }

    private bool Handle_CMSG_AUTH_SESSION(WorldOpcode opcode, SocketStream stream, CancellationToken cancel)
    {
        var reader = stream.Reader;

        var clientBuild = reader.ReadInt32();
        var unk2 = reader.ReadInt32();
        var name = reader.ReadNullTerminatedString();
        var clientSeed = reader.ReadBytes(4);
        var digest = reader.ReadBytes(20);
        var serverSeed = stream.GetAndClearMetadata<byte[]>("ServerSeed");
        var addonLength = reader.ReadInt32();


        _logger.LogInformation("WorldSocket::HandleAuthSession: client build {}, account {}, clientseed {}",
            clientBuild, name, Convert.ToHexString(clientSeed));

        if (!_buildInfoService.Builds.ContainsKey(clientBuild))
        {
            _sender.Send(stream, WorldOpcode.SMSG_AUTH_RESPONSE,
                writer => { writer.Write((int)ResponseCode.AUTH_VERSION_MISMATCH); });
            return true;
        }

        AuthState state;
        var loginResult = _database.UseLogin(db =>
        {
            var userName = name;
            var account = db.Accounts.FirstOrDefault(x => x.Username == userName);
            if (account == default)
            {
                _sender.Send(stream, WorldOpcode.SMSG_AUTH_RESPONSE,
                    writer => { writer.Write((int)ResponseCode.AUTH_UNKNOWN_ACCOUNT); });
                _logger.LogError("WorldSocket::HandleAuthSession: Sent Auth Response (unknown account). ");
                return false;
            }

            _logger.LogDebug("WorldSocket::HandleAuthSession: (s,v) check s: {} v: {}",
                account.S, account.V);

            // Re-check ip locking (same check as in realmd).
            if (account.Locked != 0 && account.LockedIp != stream.RemoteEndPoint.Split(':')[0])
            {
                _sender.Send(stream, WorldOpcode.SMSG_AUTH_RESPONSE,
                    writer => { writer.Write((int)ResponseCode.AUTH_FAILED); });
                _logger.LogWarning("WorldSocket::HandleAuthSession: Sent Auth Response (Account IP differs.)");
                return false;
            }

            var accountId = (long)account.Id;
            var now = DateTimeOffset.Now.ToUnixTimeSeconds();
            var security = (AccountType)account.Gmlevel;
            if (security > AccountType.ADMINISTRATOR)
                security = AccountType.ADMINISTRATOR;

            state = _authService.CreateState(accountId, userName.AsMemory(),
                Convert.FromHexString(account.Sessionkey).AsMemory().Reversed());
            stream.SetMetadata(nameof(AuthState), state);
            state.Encrypted = true;

            var muteTime = DateTimeOffset.FromUnixTimeSeconds((long)account.Mutetime);
            var locale = account.Locale;
            var os = account.Os;
            var flags = unchecked((AccountFlags)account.Flags);

            // Re-check account ban (same check as in realmd)
            var accountBan = _accountService.GetActiveAccountBan(db, accountId);
            if (accountBan != default)
            {
                _sender.Send(stream, WorldOpcode.SMSG_AUTH_RESPONSE,
                    writer => { writer.Write((int)ResponseCode.AUTH_BANNED); });
                _logger.LogError("WorldSocket::HandleAuthSession: Sent Auth Response (Account banned). ");
                return false;
            }

            // Check locked state for server
            if (!_accountService.IsAccountAuthorized(db, accountId, security))
            {
                _sender.Send(stream, WorldOpcode.SMSG_AUTH_RESPONSE,
                    writer => { writer.Write((int)ResponseCode.AUTH_UNAVAILABLE); });
                _logger.LogWarning(
                    "WorldSocket::HandleAuthSession: User tries to login but their security level is not enough");
                return false;
            }

            // Check that Key and account name are the same on client and server
            using var sha = SHA1.Create();
            using var shaBuffer = new MemoryStream();
            using var shaBufferWriter = new BinaryWriter(shaBuffer);

            var sessionKey = Convert.FromHexString(account.Sessionkey).AsSpan().Reversed();
            shaBufferWriter.Write(name.AsSpan().ToUtf8Bytes());
            shaBufferWriter.Write(0);
            shaBufferWriter.Write(clientSeed);
            shaBufferWriter.Write(serverSeed);
            shaBufferWriter.Write(sessionKey);
            shaBufferWriter.Flush();
            shaBuffer.Position = 0;

            var verifyHash = new byte[20];
            sha.TryComputeHash(shaBuffer.AsSpan(), verifyHash, out _);

            if (!verifyHash.SequenceEqual(digest))
            {
                _sender.Send(stream, WorldOpcode.SMSG_AUTH_RESPONSE,
                    writer => { writer.Write((int)ResponseCode.AUTH_FAILED); });
                _logger.LogError(
                    "WorldSocket::HandleAuthSession: Sent Auth Response (authentication failed), account ID: {}. ",
                    accountId);
                return false;
            }

            _logger.LogDebug("WorldSocket::HandleAuthSession: Client '{}' authenticated successfully from {}. ",
                name, stream.RemoteEndPoint);

            switch (os)
            {
                case "Win":
                case "OSX":
                    break;
                default:
                    _logger.LogError("WorldSocket::HandleAuthSession: Unrecognized OS '{}' for account '{}' from '{}",
                        os, name, stream.RemoteEndPoint);
                    return false;
            }

            _accountService.LogAccountLogin(db, accountId, stream.RemoteEndPoint, LoginType.MANGOSD);

            db.SaveChanges();
            return true;
        });

        if (!loginResult)
        {
            stream.Flush();
            stream.Disconnect();
            return true;
        }

        // TODO: find/replace session, check addon info, etc

        _sender.Send(stream, WorldOpcode.SMSG_AUTH_RESPONSE,
            writer =>
            {
                writer.Write((int)ResponseCode.AUTH_OK);
                writer.Write(0);
                writer.Write((byte)0);
                writer.Write(0);
            });

        return true;
    }
}