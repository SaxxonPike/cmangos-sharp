using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using MangosSharp.Core;
using MangosSharp.Core.Security;
using MangosSharp.Data.Entities.RealmDatabase;
using MangosSharp.Server.Core.Messages;
using MangosSharp.Server.Core.Services;
using MangosSharp.Server.Core.Sockets;
using MangosSharp.Server.Realm.Enums;
using MangosSharp.Server.Realm.Records;
using MangosSharp.Server.Realm.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MangosSharp.Server.Realm.Messaging;

public sealed class RealmPacketHandler : PacketHandler<RealmOpcode, SocketStream>
{
    private readonly ILogger _logger;
    private readonly IDatabase _database;
    private readonly IConfiguration _configuration;
    private readonly IAuthService _authService;
    private readonly IRealmListService _realmListService;
    private readonly IDictionary<string, LoginSession> _sessions;

    public RealmPacketHandler(ILogger logger, IDatabase database, IConfiguration configuration, IAuthService authService,
        IRealmListService realmListService)
    {
        _logger = logger;
        _database = database;
        _configuration = configuration;
        _authService = authService;
        _realmListService = realmListService;
        _sessions = new Dictionary<string, LoginSession>();
    }

    protected override int ReadOpcode(SocketStream stream) => stream.ReadByte();

    protected override IReadOnlyDictionary<RealmOpcode, OpcodeHandler<RealmOpcode, SocketStream>> GetHandlers()
    {
        return new Dictionary<RealmOpcode, OpcodeHandler<RealmOpcode, SocketStream>>
        {
            { RealmOpcode.CMD_AUTH_LOGON_CHALLENGE, HandleLogonChallenge },
            { RealmOpcode.CMD_AUTH_LOGON_PROOF, HandleLogonProof },
            { RealmOpcode.CMD_AUTH_RECONNECT_CHALLENGE, HandleReconnectChallenge },
            { RealmOpcode.CMD_AUTH_RECONNECT_PROOF, HandleReconnectProof },
            { RealmOpcode.CMD_REALM_LIST, HandleRealmList },
            { RealmOpcode.CMD_XFER_ACCEPT, HandleXferAccept },
            { RealmOpcode.CMD_XFER_RESUME, HandleXferResume },
            { RealmOpcode.CMD_XFER_CANCEL, HandleXferCancel }
        };
    }

    private static readonly byte[] VersionChallenge =
    {
        0xBA, 0xA3, 0x1E, 0x99, 0xA0, 0x0B, 0x21, 0x57,
        0xFC, 0x37, 0x3F, 0xB3, 0x69, 0xCD, 0xD2, 0xF1
    };

    private LoginSession GetSession(ISocketEndpoints endpoint) =>
        _sessions.TryGetValue(endpoint.RemoteEndPoint, out var status) ? status : default;

    private void DestroySession(ISocketEndpoints endpoint) =>
        _sessions.Remove(endpoint.RemoteEndPoint);

    private bool HandleLogonChallenge(RealmOpcode opcode, SocketStream stream, CancellationToken cancel)
    {
        _logger.LogDebug($"Entering {nameof(HandleLogonChallenge)}");

        const int packetLength = 34;
        const int packetContentLength = packetLength - 5;

        if (stream.Length < packetLength)
            return false;

        var reader = stream.Reader;
        var error = reader.ReadByte();
        int length = reader.ReadUInt16();
        _logger.LogDebug("[AuthChallenge] got header, body is 0x{:X4} bytes", length);

        var start = stream.Position;

        if (length < packetContentLength)
            return false;

        // [fox] okay, I love span<>, but using them with extension methods is fucking nuts
        var gameName = reader.ReadBytes(4).NullTerminated().Reversed().AsSpan().ToUtf8String();
        var version1 = reader.ReadByte();
        var version2 = reader.ReadByte();
        var version3 = reader.ReadByte();
        int build = reader.ReadUInt16();
        var platform = reader.ReadBytes(4).NullTerminated().Reversed().AsSpan().ToUtf8String();
        var os = reader.ReadBytes(4).NullTerminated().Reversed().AsSpan().ToUtf8String();
        var locale = reader.ReadBytes(4).NullTerminated().Reversed().AsSpan().ToUtf8String();
        long timeZoneBias = reader.ReadUInt32();
        var ip = new IPAddress(reader.ReadBytes(4)).ToString();
        var nameLength = reader.ReadByte();
        var name = Encoding.UTF8.GetString(reader.ReadBytes(nameLength));
        var remainder = reader.ReadBytes(length - (int)(stream.Position - start));
        var session = new LoginSession
        {
            Name = name,
            Build = build,
            Status = SessionStatus.CLOSED,
            Created = DateTimeOffset.Now,
            Platform = platform,
            Os = os,
            Locale = locale
        };

        _logger.LogDebug("[AuthChallenge] got full packet, {:X4} bytes", length + 5);
        _logger.LogDebug("[AuthChallenge] name({}): '{}'", nameLength, name);

        var writer = stream.Writer;
        writer.Write((byte)RealmOpcode.CMD_AUTH_LOGON_CHALLENGE);
        writer.Write((byte)0);

        var account = _database.UseLogin(db =>
        {
            var now = session.Created.ToUnixTimeSeconds();

            var ipBan = db.IpBanneds
                .Any(x => (x.ExpiresAt == x.BannedAt || x.ExpiresAt > now) && x.Ip == ip);

            if (ipBan)
            {
                writer.Write((byte)AuthLogonResult.FAILED_FAIL_NOACCESS);
                _logger.LogInformation("[AuthChallenge] Banned ip {} tries to login!", ip);
                return default;
            }

            var account = db.Accounts.FirstOrDefault(x => x.Username == name);
            if (account == default)
            {
                writer.Write((byte)AuthLogonResult.FAILED_UNKNOWN_ACCOUNT);
                return default;
            }

            session.AccountId = account.Id;

            if (account.Locked == 1)
            {
                _logger.LogDebug("[AuthChallenge] Account '{}' is locked to IP - '{}'", name, account.LockedIp);
                _logger.LogDebug("[AuthChallenge] Player address is '{}'", stream.RemoteEndPoint);
                if (stream.RemoteEndPoint.Split(';')[0] != account.LockedIp)
                {
                    _logger.LogDebug("[AuthChallenge] Account IP differs");
                    writer.Write((byte)AuthLogonResult.FAILED_SUSPENDED);
                    return default;
                }

                _logger.LogDebug("[AuthChallenge] Account IP matches");
            }
            else
            {
                _logger.LogDebug("[AuthChallenge] Account '{}' is not locked to ip", name);
            }

            if (string.IsNullOrWhiteSpace(account.S) || string.IsNullOrWhiteSpace(account.V))
            {
                _logger.LogDebug("[AuthChallenge] Broken v/s values in database for account {}!", name);
                writer.Write((byte)AuthLogonResult.FAILED_INCORRECT_PASSWORD);
                return default;
            }

            var accountId = (int)account.Id;
            var accountBan = db.AccountBanneds
                //.Select(x => new { x.AccountId, x.Active, x.ExpiresAt, x.BannedAt })
                .FirstOrDefault(x => x.AccountId == accountId &&
                                     x.Active == 1 &&
                                     (x.ExpiresAt > now || x.ExpiresAt == x.BannedAt));

            if (accountBan != default)
            {
                if (accountBan.ExpiresAt == accountBan.BannedAt)
                {
                    _logger.LogInformation("[AuthChallenge] Banned account {} tries to login!", name);
                    writer.Write((byte)AuthLogonResult.FAILED_BANNED);
                    return default;
                }
                else
                {
                    _logger.LogInformation("[AuthChallenge] Temporarily banned account {} tries to login!", name);
                    writer.Write((byte)AuthLogonResult.FAILED_SUSPENDED);
                    return default;
                }
            }

            _logger.LogDebug("Database authentication values: v='{}' s='{}'",
                account.V,
                account.S);

            var accountV = Convert.FromHexString(account.V).AsSpan().Reversed();
            var accountS = Convert.FromHexString(account.S).AsSpan().Reversed();

            var challenge = _authService.CreateChallenge(stream.RemoteEndPoint, account.Id, account.Username.AsMemory(),
                accountV, accountS);
            writer.Write((byte)AuthLogonResult.SUCCESS);

            // B may be calculated < 32B so we force minimal length to 32B
            writer.Write(challenge.ServerPublicKey.Span);
            writer.Write((byte)1);
            writer.Write(challenge.Generator.Span);
            writer.Write((byte)32);
            writer.Write(challenge.LargeSafePrime.Span);
            writer.Write(accountS);
            writer.Write(VersionChallenge);

            return account;
        });

        if (account == default)
            return false;

        SecurityFlag securityFlags = 0;
        var token = account.Token;
        if (!string.IsNullOrEmpty(token) && build >= 8606) // authenticator was added in 2.4.3
            securityFlags = SecurityFlag.AUTHENTICATOR;

        writer.Write((byte)securityFlags); // security flags (0x0...0x04)

        if (securityFlags.HasFlag(SecurityFlag.PIN)) // PIN input
        {
            writer.Write(0);
            writer.Write((long)0);
            writer.Write((long)0);
        }

        if (securityFlags.HasFlag(SecurityFlag.UNK))
        {
            writer.Write((byte)0);
            writer.Write((byte)0);
            writer.Write((byte)0);
            writer.Write((byte)0);
            writer.Write((long)0);
        }

        if (securityFlags.HasFlag(SecurityFlag.AUTHENTICATOR))
            writer.Write((byte)1);

        var secLevel = (AccountType)account.Gmlevel;
        if (secLevel > AccountType.ADMINISTRATOR)
            secLevel = AccountType.ADMINISTRATOR;

        session.Level = secLevel;
        session.Flags = securityFlags;
        session.Status = SessionStatus.LOGON_PROOF;
        session.Token = token;
        _sessions[stream.RemoteEndPoint] = session;
        return true;
    }

    private bool HandleLogonProof(RealmOpcode opcode, SocketStream stream, CancellationToken cancel)
    {
        if (GetSession(stream) is not { Status: SessionStatus.LOGON_PROOF } session)
            return false;

        _logger.LogDebug($"Entering {nameof(HandleLogonProof)}");

        const int packetLength = 74;

        if (stream.Length < packetLength)
            return false;

        var reader = stream.Reader;
        var writer = stream.Writer;

        var a = reader.ReadBytes(32);
        var m1 = reader.ReadBytes(20);
        var crcHash = reader.ReadBytes(20);
        var numberOfKeys = reader.ReadByte();
        var securityFlags = reader.ReadByte();

        if (FindBuildInfo(session.Build) == default)
        {
            // no patch found
            writer.Write((byte)RealmOpcode.CMD_AUTH_LOGON_PROOF);
            writer.Write((byte)0);
            writer.Write((byte)AuthLogonResult.FAILED_VERSION_INVALID);

            _logger.LogInformation("[AuthChallenge] Account {} tried to login with invalid client version {}!",
                session.Name, session.Build);
            DestroySession(stream);
            return false;
        }

        var result = _authService.VerifyChallenge(stream.RemoteEndPoint, a, m1);
        if (result is { SessionKey.IsEmpty: false })
        {
            if (!string.IsNullOrEmpty(session.Token) || session.Flags.HasFlag(SecurityFlag.AUTHENTICATOR))
            {
                var pinCount = reader.ReadByte();
                var keys = reader.ReadBytes(pinCount);
                var serverToken = GenerateToken(session.Token);
                var clientToken = int.Parse(Encoding.UTF8.GetString(keys));
                if (serverToken != clientToken)
                {
                    _logger.LogInformation(
                        "[AuthChallenge] Account {} tried to login with wrong pincode! Given {} expected {} pin count {}",
                        session.Name, clientToken, serverToken, pinCount);
                    DestroySession(stream);
                    return false;
                }
            }

            if (!VerifyVersion(session, a, crcHash, false))
            {
                _logger.LogInformation("[AuthChallenge] Account {} tried to login with modified client!", session.Name);
                DestroySession(stream);
                return false;
            }

            _logger.LogInformation("User '{}' successfully authenticated", session.Name);

            _database.UseLogin(db =>
            {
                var accountId = (uint)session.AccountId;
                var account = db.Accounts.AsTracking()
                    .FirstOrDefault(x => x.Id == accountId);
                if (account == default)
                    return;

                account.Sessionkey = Convert.ToHexString(result.SessionKey.Reversed());
                account.Locale = session.Locale;
                account.FailedLogins = 0;
                account.Os = session.Os;

                db.AccountLogons.Add(new AccountLogons
                {
                    AccountId = (uint)session.AccountId,
                    Ip = stream.RemoteEndPoint.Split(';')[0],
                    LoginTime = DateTime.Now,
                    LoginSource = (uint)LoginType.REALMD
                });

                db.SaveChanges();
            });

            SendProof(session, stream, result);
            session.Status = SessionStatus.AUTHED;
            return true;
        }

        writer.Write((byte)RealmOpcode.CMD_AUTH_LOGON_PROOF);
        writer.Write((byte)AuthLogonResult.FAILED_UNKNOWN_ACCOUNT);

        if (session.Build > 6005) // > 1.12.2
        {
            writer.Write((byte)0);
            writer.Write((byte)0);
        }

        _logger.LogInformation("[AuthChallenge] account {} tried to login with wrong password!", session.Name);

        var maxWrongPassCount = _configuration.GetValue("WrongPass.MaxCount", 0);
        if (maxWrongPassCount > 0)
        {
            // Increment number of failed logins by one and if it reaches the limit temporarily ban that account or IP
            _database.UseLogin(db =>
            {
                var accountId = (uint)session.AccountId;
                var account = db.Accounts.AsTracking().FirstOrDefault(x => x.Id == accountId);
                if (account == default)
                    return;

                account.FailedLogins++;
                if (account.FailedLogins >= maxWrongPassCount)
                {
                    var wrongPassBanTime = _configuration.GetValue("WrongPass.BanTime", 600);
                    var wrongPassBanType = _configuration.GetValue("WrongPass.BanType", 0) == 1;

                    if (wrongPassBanType)
                    {
                        db.AccountBanneds.Add(new AccountBanned
                        {
                            AccountId = (int)account.Id,
                            BannedAt = DateTimeOffset.Now.ToUnixTimeSeconds(),
                            ExpiresAt = DateTimeOffset.Now.AddSeconds(wrongPassBanTime).ToUnixTimeSeconds(),
                            BannedBy = "MaNGOS realmd",
                            Reason = "Failed login autoban",
                            Active = 1
                        });
                    }
                    else
                    {
                        db.IpBanneds.Add(new IpBanned
                        {
                            Ip = stream.RemoteEndPoint.Split(';')[0],
                            BannedAt = DateTimeOffset.Now.ToUnixTimeSeconds(),
                            ExpiresAt = DateTimeOffset.Now.AddSeconds(wrongPassBanTime).ToUnixTimeSeconds(),
                            BannedBy = "MaNGOS realmd",
                            Reason = "Failed login autoban"
                        });
                    }
                }

                db.SaveChanges();
            });
        }

        DestroySession(stream);
        return false;
    }

    [SuppressMessage("ReSharper", "RedundantCaseLabel")]
    private static void SendProof(LoginSession session, SocketStream stream, AuthChallengeServer result)
    {
        var writer = stream.Writer;

        switch (session.Build)
        {
            case 5875: // 1.12.1
            case 6005: // 1.12.2
            case 6141: // 1.12.3
            {
                writer.Write((byte)RealmOpcode.CMD_AUTH_LOGON_PROOF);
                writer.Write((byte)0); // error code
                writer.Write(result.ServerProof.Span);
                writer.Write(0); // flags
                break;
            }
            case 8606: // 2.4.3
            case 10505: // 3.2.2a
            case 11159: // 3.3.0a
            case 11403: // 3.3.2
            case 11723: // 3.3.3a
            case 12340: // 3.3.5a
            default: // or later
            {
                writer.Write((byte)RealmOpcode.CMD_AUTH_LOGON_PROOF);
                writer.Write((byte)0); // error code
                writer.Write(result.ServerProof.Span);
                writer.Write((int)AccountFlags.ACCOUNT_FLAG_PROPASS);
                writer.Write(0); // survey ID
                writer.Write((short)0); // unknown flags
                break;
            }
        }
    }

    private bool VerifyVersion(LoginSession session, ReadOnlySpan<byte> a, ReadOnlySpan<byte> versionProof,
        bool isReconnect)
    {
        if (_configuration.GetValue("StrictVersionCheck", 0) == 0)
            return true;

        var zero = new byte[20];
        ReadOnlyMemory<byte> versionHash;
        if (!isReconnect)
        {
            var buildInfo = FindBuildInfo(session.Build);
            if (buildInfo == default)
                return false;

            versionHash = session.Os switch
            {
                "Win" => buildInfo.WindowsHash,
                "OSX" => buildInfo.MacHash,
                _ => default
            };

            if (versionHash.IsEmpty)
                return false;
            if (versionHash.Span.SequenceEqual(zero))
                return true;
        }
        else
        {
            versionHash = zero;
        }

        var versionBytes = new byte[a.Length + versionHash.Length];
        a.CopyTo(versionBytes);
        versionHash.CopyTo(versionBytes.AsMemory(a.Length));

        var sha1 = SHA1.Create();
        var version = sha1.ComputeHash(versionBytes);
        return version.AsSpan().SequenceEqual(versionProof);
    }

    private static int GenerateToken(string token)
    {
        var timestamp = DateTimeOffset.Now.ToUnixTimeSeconds() / 30;
        var challenge = new byte[8];
        for (var i = 8; i-- > 0; timestamp >>= 8)
            challenge[i] = unchecked((byte)timestamp);
        var key = Base32.FromBase32String(token);
        var hash = HMACSHA1.HashData(key, challenge);
        var offset = hash[19] & 0xF;
        var truncHash = ((hash[offset] << 24) | (hash[offset + 1] << 16) | (hash[offset + 2] << 8) | hash[offset + 3])
                        & 0x7FFFFFFF;
        return truncHash % 1000000;
    }

    private RealmBuildInfo FindBuildInfo(int build) =>
        _realmListService.Builds.TryGetValue(build, out var info) ? info : default;

    private bool HandleReconnectChallenge(RealmOpcode opcode, SocketStream stream, CancellationToken cancel)
    {
        throw new NotImplementedException();
    }

    private bool HandleReconnectProof(RealmOpcode opcode, SocketStream stream, CancellationToken cancel)
    {
        throw new NotImplementedException();
    }

    private bool HandleRealmList(RealmOpcode opcode, SocketStream stream, CancellationToken cancel)
    {
        _logger.LogDebug($"Entering {nameof(HandleRealmList)}");
        if (stream.Available < 4)
            return false;

        var session = GetSession(stream);
        if (session.Status != SessionStatus.AUTHED)
            return false;

        _realmListService.UpdateIfNeed();

        // [fox] Filter up here once instead of in the below loop
        var realms = _realmListService
            .LoadRealmList((int)session.AccountId, session.Level)
            .ToList();

        // [fox] Get all RealmCharacters at once instead of per-realm
        var realmCharacters = _database.UseLogin(db =>
        {
            var accountId = (ulong)session.AccountId;
            return db.Realmcharacters
                .Where(x => x.Acctid == accountId)
                .ToList();
        });

        var mem = new MemoryStream();
        var writer = new BinaryWriter(mem);

        var build = _realmListService.Builds.FirstOrDefault(b => b.Key == session.Build).Value;

        // 1.x clients not support explicitly REALM_FLAG_SPECIFYBUILD, so manually form similar name as show in more recent clients
        string GetRealmName(RealmEntry re) =>
            re.Name +
            (re.Flags.HasFlag(RealmFlag.SPECIFYBUILD)
                ? $" ({build.Major},{build.Minor},{build.Bugfix})"
                : string.Empty);

        bool IsOkBuild() =>
            build != null && _realmListService.Builds.ContainsKey(build.Build);

        var visibleRealms = realms
            .OrderBy(x => x.Name)
            .Where(x => x.AllowedSecurityLevel < 1 || session.Level > AccountType.PLAYER)
            .ToList();

        // ReSharper disable RedundantCaseLabel
        switch (session.Build)
        {
            case 5875: // 1.12.1
            case 6005: // 1.12.2
            case 6141: // 1.12.3
            {
                writer.Write(0); // unused value
                writer.Write((byte)visibleRealms.Count);

                byte index = 0;
                foreach (var realm in visibleRealms)
                {
                    var okBuild = IsOkBuild();
                    var flags = realm.Flags;

                    // Show offline state for unsupported client builds and locked realms (1.x clients not support locked state show)
                    if (!okBuild || (int)session.Level < realm.AllowedSecurityLevel)
                        flags |= RealmFlag.OFFLINE;

                    // [fox] don't rely on database type not changing for this
                    int realmCharCount = realmCharacters.FirstOrDefault(x => realm.Id == x.Realmid)?.Numchars ?? 0;
                    writer.Write(realm.Icon);
                    writer.Write((byte)flags);
                    writer.Write(GetRealmName(realm).AsSpan().ToUtf8Bytes());
                    writer.Write((byte)0);
                    writer.Write(realm.Endpoint.AsSpan().ToUtf8Bytes());
                    writer.Write((byte)0);
                    writer.Write(realm.PopulationLevel);
                    writer.Write((byte)realmCharCount);
                    writer.Write((byte)realm.TimeZone);
                    writer.Write(index++); // [fox] some docs say sort index, I don't know
                }

                writer.Write((short)0x0002); // unused value (why 2?)
                break;
            }
            case 8606: // 2.4.3
            case 10505: // 3.2.2a
            case 11159: // 3.3.0a
            case 11403: // 3.3.2
            case 11723: // 3.3.3a
            case 12340: // 3.3.5a
            default:
            {
                writer.Write(0);
                writer.Write((short)visibleRealms.Count);

                byte index = 0;
                foreach (var realm in visibleRealms)
                {
                    var okBuild = IsOkBuild();
                    var flags = realm.Flags;
                    var locked = (int)session.Level < realm.AllowedSecurityLevel;

                    // Show offline state for unsupported client builds
                    if (!okBuild)
                        flags |= RealmFlag.OFFLINE;

                    // [fox] don't rely on database type not changing for this
                    int realmCharCount = realmCharacters.FirstOrDefault(x => realm.Id == x.Realmid)?.Numchars ?? 0;
                    writer.Write(realm.Icon);
                    writer.Write(locked);
                    writer.Write((byte)flags);
                    writer.Write(realm.Name.AsSpan().ToUtf8Bytes());
                    writer.Write((byte)0);
                    writer.Write(realm.Endpoint.AsSpan().ToUtf8Bytes());
                    writer.Write((byte)0);
                    writer.Write(realm.PopulationLevel);
                    writer.Write((byte)realmCharCount);
                    writer.Write((byte)realm.TimeZone);
                    writer.Write(index++); // [fox] some docs say sort index, I don't know

                    if (realm.Flags.HasFlag(RealmFlag.SPECIFYBUILD))
                    {
                        writer.Write((byte)build.Major);
                        writer.Write((byte)build.Minor);
                        writer.Write((byte)build.Bugfix);
                        writer.Write((ushort)build.Build);
                    }
                }

                writer.Write((short)0x0010); // unused value (why 10?)
                break;
            }
        }
        // ReSharper restore RedundantCaseLabel

        mem.Flush();
        mem.Position = 0;
        var packetWriter = stream.Writer;
        packetWriter.Write((byte)RealmOpcode.CMD_REALM_LIST);
        packetWriter.Write((ushort)mem.Length);
        packetWriter.Write(mem.AsSpan());
        return true;
    }

    private bool HandleXferAccept(RealmOpcode opcode, SocketStream stream, CancellationToken cancel)
    {
        throw new NotImplementedException();
    }

    private bool HandleXferResume(RealmOpcode opcode, SocketStream stream, CancellationToken cancel)
    {
        throw new NotImplementedException();
    }

    private bool HandleXferCancel(RealmOpcode opcode, SocketStream stream, CancellationToken cancel)
    {
        throw new NotImplementedException();
    }
}