using System;

namespace MangosSharp.Server.Core.Enums;

[Flags]
public enum AccountFlags
{
    ACCOUNT_FLAG_GM = 0x00000001,
    ACCOUNT_FLAG_TRIAL = 0x00000008,
    ACCOUNT_FLAG_PROPASS = 0x00800000
}
