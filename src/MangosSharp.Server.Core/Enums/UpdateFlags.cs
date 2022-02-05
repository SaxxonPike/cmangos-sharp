using System;

namespace MangosSharp.Server.Core.Enums;

[Flags]
public enum UpdateFlags
{
    NONE = 0x0000,
    SELF = 0x0001,
    TRANSPORT = 0x0002,
    HAS_TARGET = 0x0004,
    HIGHGUID = 0x0008,
    ALL = 0x0010,
    LIVING = 0x0020,
    HAS_POSITION = 0x0040
}