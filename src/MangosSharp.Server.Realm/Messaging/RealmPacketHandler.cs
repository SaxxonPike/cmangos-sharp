using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MangosSharp.Server.Realm.Messaging;

public sealed class RealmPacketHandler : PacketHandler<RealmOpcode, SocketStream>
{
    private readonly ILogger _logger;
    private readonly IDatabase _database;
    private readonly IConfiguration _configuration;
    private readonly IAuthEngine _authEngine;
    private readonly IDictionary<string, LoginSession> _sessions;

    public RealmPacketHandler(ILogger logger, IDatabase database, IConfiguration configuration, IAuthEngine authEngine)
    {
        _logger = logger;
        _database = database;
        _configuration = configuration;
        _authEngine = authEngine;
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

    private static readonly IReadOnlyDictionary<int, RealmBuildInfo> ExpectedRealmdClientBuilds =
        new Dictionary<int, RealmBuildInfo>
        {
            {
                13930,
                new RealmBuildInfo(13930, 3, 3, 5, 'a',
                    Array.Empty<byte>(),
                    Array.Empty<byte>()
                )
            },
            {
                12340,
                new RealmBuildInfo(12340, 3, 3, 5, 'a',
                    new byte[]
                    {
                        0xCD, 0xCB, 0xBD, 0x51, 0x88, 0x31, 0x5E, 0x6B, 0x4D, 0x19,
                        0x44, 0x9D, 0x49, 0x2D, 0xBC, 0xFA, 0xF1, 0x56, 0xA3, 0x47
                    },
                    new byte[]
                    {
                        0xB7, 0x06, 0xD1, 0x3F, 0xF2, 0xF4, 0x01, 0x88, 0x39, 0x72,
                        0x94, 0x61, 0xE3, 0xF8, 0xA0, 0xE2, 0xB5, 0xFD, 0xC0, 0x34
                    }
                )
            },
            {
                11723,
                new RealmBuildInfo(11723, 3, 3, 3, 'a',
                    Array.Empty<byte>(),
                    Array.Empty<byte>()
                )
            },
            {
                11403,
                new RealmBuildInfo(11403, 3, 3, 2, ' ',
                    Array.Empty<byte>(),
                    Array.Empty<byte>()
                )
            },
            {
                11159,
                new RealmBuildInfo(11159, 3, 3, 0, 'a',
                    Array.Empty<byte>(),
                    Array.Empty<byte>()
                )
            },
            {
                10505,
                new RealmBuildInfo(10505, 3, 2, 2, 'a',
                    Array.Empty<byte>(),
                    Array.Empty<byte>()
                )
            },
            {
                9947,
                new RealmBuildInfo(9947, 3, 1, 3, ' ',
                    Array.Empty<byte>(),
                    Array.Empty<byte>()
                )
            },
            {
                8606,
                new RealmBuildInfo(8606, 2, 4, 3, ' ',
                    new byte[]
                    {
                        0x31, 0x9A, 0xFA, 0xA3, 0xF2, 0x55, 0x96, 0x82, 0xF9, 0xFF,
                        0x65, 0x8B, 0xE0, 0x14, 0x56, 0x25, 0x5F, 0x45, 0x6F, 0xB1
                    },
                    new byte[]
                    {
                        0xD8, 0xB0, 0xEC, 0xFE, 0x53, 0x4B, 0xC1, 0x13, 0x1E, 0x19,
                        0xBA, 0xD1, 0xD4, 0xC0, 0xE8, 0x13, 0xEE, 0xE4, 0x99, 0x4F
                    }
                )
            },
            {
                6141,
                new RealmBuildInfo(6141, 1, 12, 3, ' ',
                    new byte[]
                    {
                        0xEB, 0x88, 0x24, 0x3E, 0x94, 0x26, 0xC9, 0xD6, 0x8C, 0x81,
                        0x87, 0xF7, 0xDA, 0xE2, 0x25, 0xEA, 0xF3, 0x88, 0xD8, 0xAF
                    },
                    Array.Empty<byte>()
                )
            },
            {
                6005,
                new RealmBuildInfo(6005, 1, 12, 2, ' ',
                    new byte[]
                    {
                        0x06, 0x97, 0x32, 0x38, 0x76, 0x56, 0x96, 0x41, 0x48, 0x79,
                        0x28, 0xFD, 0xC7, 0xC9, 0xE3, 0x3B, 0x44, 0x70, 0xC8, 0x80
                    },
                    Array.Empty<byte>()
                )
            },
            {
                5875,
                new RealmBuildInfo(5875, 1, 12, 1, ' ',
                    new byte[]
                    {
                        0x95, 0xED, 0xB2, 0x7C, 0x78, 0x23, 0xB3, 0x63, 0xCB, 0xDD,
                        0xAB, 0x56, 0xA3, 0x92, 0xE7, 0xCB, 0x73, 0xFC, 0xCA, 0x20
                    },
                    new byte[]
                    {
                        0x8D, 0x17, 0x3C, 0xC3, 0x81, 0x96, 0x1E, 0xEB, 0xAB, 0xF3,
                        0x36, 0xF5, 0xE6, 0x67, 0x5B, 0x10, 0x1B, 0xB5, 0x13, 0xE5
                    }
                )
            },
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
                .FirstOrDefault(x => (x.ExpiresAt == x.BannedAt || x.ExpiresAt > now) && x.Ip == ip);

            if (ipBan != default)
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

            var accountBan = db.AccountBanneds
                .FirstOrDefault(x => x.AccountId == account.Id &&
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
            
            var challenge = _authEngine.CreateChallenge(stream.RemoteEndPoint, account.Id, account.Username.AsMemory(),
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

        var secLevel = (AccountTypes)account.Gmlevel;
        if (secLevel > AccountTypes.ADMINISTRATOR)
            secLevel = AccountTypes.ADMINISTRATOR;

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

        var result = _authEngine.VerifyChallenge(stream.RemoteEndPoint, a, m1);
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
                var account = db.Accounts.Find(session.AccountId);
                if (account == default)
                    return;

                account.Sessionkey = Convert.ToHexString(result.SessionKey.Reversed());
                account.Locale = session.Locale;
                account.FailedLogins = 0;
                account.Os = session.Os;

                db.AccountLogons.Add(new AccountLogons
                {
                    AccountId = (uint) session.AccountId,
                    Ip = stream.RemoteEndPoint.Split(';')[0],
                    LoginTime = DateTime.Now,
                    LoginSource = (uint)LoginType.REALMD
                });

                db.SaveChanges();
            });

            SendProof(session, stream, result);
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
                var account = db.Accounts.Find(session.AccountId);
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
                writer.Write((byte) RealmOpcode.CMD_AUTH_LOGON_PROOF);
                writer.Write((byte) 0); // error code
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
                writer.Write((byte) RealmOpcode.CMD_AUTH_LOGON_PROOF);
                writer.Write((byte) 0); // error code
                writer.Write(result.ServerProof.Span);
                writer.Write((int) AccountFlags.ACCOUNT_FLAG_PROPASS);
                writer.Write(0); // survey ID
                writer.Write((short) 0); // unknown flags
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
        ExpectedRealmdClientBuilds.TryGetValue(build, out var info) ? info : default;

    private bool HandleReconnectChallenge(RealmOpcode opcode, SocketStream stream, CancellationToken cancel)
    {
        throw new System.NotImplementedException();
    }

    private bool HandleReconnectProof(RealmOpcode opcode, SocketStream stream, CancellationToken cancel)
    {
        throw new System.NotImplementedException();
    }

    private bool HandleRealmList(RealmOpcode opcode, SocketStream stream, CancellationToken cancel)
    {
        _logger.LogDebug($"Entering {nameof(HandleRealmList)}");
        if (stream.Available < 4)
            return false;

        var session = GetSession(stream);
        if (session.Status != SessionStatus.AUTHED)
            return false;

        return true;
    }

    private bool HandleXferAccept(RealmOpcode opcode, SocketStream stream, CancellationToken cancel)
    {
        throw new System.NotImplementedException();
    }

    private bool HandleXferResume(RealmOpcode opcode, SocketStream stream, CancellationToken cancel)
    {
        throw new System.NotImplementedException();
    }

    private bool HandleXferCancel(RealmOpcode opcode, SocketStream stream, CancellationToken cancel)
    {
        throw new System.NotImplementedException();
    }
}