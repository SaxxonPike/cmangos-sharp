using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using MangosSharp.Core;
using MangosSharp.Core.Security;
using MangosSharp.Data.Entities.RealmDatabase;
using MangosSharp.Server.Core.Enums;
using MangosSharp.Server.Core.Messages;
using MangosSharp.Server.Core.Services;
using MangosSharp.Server.Core.Sockets;
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

    public WorldPacketHandler(IAuthService authService, IDatabase database, IBuildInfoService buildInfoService,
        ILogger logger, IWorldPacketSender sender, IAccountService accountService)
    {
        _authService = authService;
        _database = database;
        _buildInfoService = buildInfoService;
        _logger = logger;
        _sender = sender;
        _accountService = accountService;
    }

    protected override int ReadOpcode(SocketStream stream) =>
        stream.Reader.ReadInt32();

    protected override IReadOnlyDictionary<WorldOpcode, OpcodeHandler<WorldOpcode, SocketStream>> GetHandlers()
    {
        // TODO: fill in these packets

        return new Dictionary<WorldOpcode, OpcodeHandler<WorldOpcode, SocketStream>>
        {
            { WorldOpcode.CMSG_AUTH_SESSION, Handle_CMSG_AUTH_SESSION }
        };
    }

    private bool Handle_CMSG_AUTH_SESSION(WorldOpcode opcode, SocketStream stream, CancellationToken cancel)
    {
        var reader = stream.Reader;

        var clientBuild = reader.ReadInt32();
        var unk2 = reader.ReadInt32();
        var name = reader.ReadNullTerminatedString();
        var clientSeed = reader.ReadBytes(4);
        var digest = reader.ReadBytes(20);
        var serverSeed = Convert.FromHexString(stream.ClearMetadata("seed"));
        var addonLength = reader.ReadInt32();
        
        
        _logger.LogInformation("WorldSocket::HandleAuthSession: client build {}, account {}, clientseed {:X8}",
            clientBuild, name, clientSeed);

        if (!_buildInfoService.Builds.ContainsKey(clientBuild))
        {
            _sender.Send(stream, WorldOpcode.SMSG_AUTH_RESPONSE,
                writer => { writer.Write((int)ResponseCode.AUTH_VERSION_MISMATCH); });
            return true;
        }

        AuthState state = default;
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

            _authService.DeleteState(stream.RemoteEndPoint);
            state = _authService.CreateState(stream.RemoteEndPoint, accountId, userName.AsMemory(),
                Convert.FromHexString(account.Sessionkey).AsMemory().Reversed());
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