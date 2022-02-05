using System;

namespace MangosSharp.Server.Core.Enums;

[Flags]
public enum TypeMask : byte
{
    OBJECT = 0x0001,
    ITEM = 0x0002,
    CONTAINER = 0x0004,
    UNIT = 0x0008, // players also have it
    PLAYER = 0x0010,
    GAMEOBJECT = 0x0020,
    DYNAMICOBJECT = 0x0040,
    CORPSE = 0x0080,

    // used combinations in Player::GetObjectByTypeMask (TYPEMASK_UNIT case ignore players in call)
    CREATURE_OR_GAMEOBJECT = UNIT | GAMEOBJECT,
    CREATURE_GAMEOBJECT_OR_ITEM = UNIT | GAMEOBJECT | ITEM,
    CREATURE_GAMEOBJECT_PLAYER_OR_ITEM = UNIT | GAMEOBJECT | ITEM | PLAYER
}