using System;

namespace MangosSharp.Server.Realm.Enums;

[Flags]
public enum SecurityFlags
{
    SECURITY_FLAG_NONE = 0x00,
    SECURITY_FLAG_PIN = 0x01,
    SECURITY_FLAG_UNK = 0x02,
    SECURITY_FLAG_AUTHENTICATOR = 0x04
}