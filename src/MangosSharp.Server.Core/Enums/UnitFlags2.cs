using System;

namespace MangosSharp.Server.Core.Enums;

[Flags]
public enum UnitFlags2
{
    UNK0 = 0x01,
    UNK1 = 0x02,
    UNK2 = 0x04,
    UNK3 = 0x08,
    AURAS = 0x10, // show positive auras as positive, and allow its dispel
    UNK5 = 0x20,
    UNK6 = 0x40,
    UNK7 = 0x80
}