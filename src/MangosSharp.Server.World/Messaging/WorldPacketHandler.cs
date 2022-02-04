using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
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

    public WorldPacketHandler(IAuthService authService, IDatabase database, IBuildInfoService buildInfoService,
        ILogger logger, IWorldPacketSender sender)
    {
        _authService = authService;
        _database = database;
        _buildInfoService = buildInfoService;
        _logger = logger;
        _sender = sender;
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
        // WIP: remove
        return false;
        
        var reader = stream.Reader;
        var clientBuild = reader.ReadInt32();
        var unk2 = reader.ReadInt32();
        var name = reader.ReadNullTerminatedString();
        var clientSeed = reader.ReadInt32();
        var digest = reader.ReadBytes(20);

        _logger.LogInformation("WorldSocket::HandleAuthSession: client build {}, account {}, clientseed {:X8}",
            clientBuild, name, clientSeed);

        if (!_buildInfoService.Builds.ContainsKey(clientBuild))
        {
            _sender.Send(stream.RemoteEndPoint, WorldOpcode.SMSG_AUTH_RESPONSE, writer =>
            {
                writer.Write((byte) ResponseCode.AUTH_VERSION_MISMATCH);
            });
            return false;
        }

        Account account = default;
        var loginResult = _database.UseLogin(db =>
        {
            var userName = name;
            var account = db.Accounts.FirstOrDefault(x => x.Username == userName);
            if (account == default)
            {
                _sender.Send(stream.RemoteEndPoint, WorldOpcode.SMSG_AUTH_RESPONSE, writer =>
                {
                    writer.Write((byte)ResponseCode.AUTH_UNKNOWN_ACCOUNT);
                });
                _logger.LogError("WorldSocket::HandleAuthSession: Sent Auth Response (unknown account). ");
                return false;
            }

            _logger.LogDebug("WorldSocket::HandleAuthSession: (s,v) check s: {} v: {}",
                account.S, account.V);
            
            // Re-check ip locking (same check as in realmd).
            if (account.Locked != 0 && account.LockedIp != stream.RemoteEndPoint.Split(';')[0])
            {
                _sender.Send(stream.RemoteEndPoint, WorldOpcode.SMSG_AUTH_RESPONSE, writer =>
                {
                    writer.Write((byte)ResponseCode.AUTH_FAILED);
                });
                _logger.LogWarning("WorldSocket::HandleAuthSession: Sent Auth Response (Account IP differs.)");
                return false;
            }
            
            var accountId = (int)account.Id;
            var now = DateTimeOffset.Now.ToUnixTimeSeconds();
            var security = (AccountType)account.Gmlevel;
            if (security > AccountType.ADMINISTRATOR)
                security = AccountType.ADMINISTRATOR;
            
            _authService.DeleteState(stream.RemoteEndPoint);
            _authService.CreateState(stream.RemoteEndPoint, accountId, userName.AsMemory(),
                Convert.FromHexString(account.Sessionkey).AsMemory().Reversed());

            var muteTime = DateTimeOffset.FromUnixTimeSeconds((long)account.Mutetime);
            var locale = account.Locale;
            var os = account.Os;
            var flags = unchecked((AccountFlags) account.Flags);
            
            // Re-check account ban (same check as in realmd)
            var accountBan = db.AccountBanneds
                .FirstOrDefault(x => x.AccountId == accountId &&
                                     x.Active == 1 &&
                                     (x.ExpiresAt > now || x.ExpiresAt == x.BannedAt));

            if (accountBan != default)
            {
                _sender.Send(stream.RemoteEndPoint, WorldOpcode.SMSG_AUTH_RESPONSE, writer =>
                {
                    writer.Write((byte)ResponseCode.AUTH_BANNED);
                });
                _logger.LogError("WorldSocket::HandleAuthSession: Sent Auth Response (Account banned). ");
                return false;
            }

            return true;
        });



        return false;
    }
}