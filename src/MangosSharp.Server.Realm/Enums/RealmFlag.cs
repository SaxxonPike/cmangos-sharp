using System;

namespace MangosSharp.Server.Realm.Enums;

[Flags]
public enum RealmFlag
{
    NONE = 0x00,
    INVALID = 0x01,
    OFFLINE = 0x02,
    SPECIFYBUILD = 0x04, // client will show realm version in RealmList screen in form "RealmName (major.minor.revision.build)"
    UNK1 = 0x08,
    UNK2 = 0x10,
    NEW_PLAYERS = 0x20,
    RECOMMENDED = 0x40,
    FULL = 0x80
}