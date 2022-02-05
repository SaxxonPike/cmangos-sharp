using System;

namespace MangosSharp.Server.Core.Enums;

[Flags]
public enum UnitFlags
{
    NONE                  = 0x00000000,
    UNK_0                 = 0x00000001,
    NON_ATTACKABLE        = 0x00000002,           ///< not attackable
    CLIENT_CONTROL_LOST   = 0x00000004,           // Generic unspecified loss of control initiated by server script, movement checks disabled, paired with loss of client control packet.
    PVP_ATTACKABLE        = 0x00000008,           ///< allow apply pvp rules to attackable state in addition to faction dependent state, UNKNOWN1 in pre-bc mangos
    RENAME                = 0x00000010,           ///< rename creature
    RESTING               = 0x00000020,
    UNK_6                 = 0x00000040,
    OOC_NOT_ATTACKABLE    = 0x00000100,           ///< (OOC Out Of Combat) Can not be attacked when not in combat. Removed if unit for some reason enter combat (flag probably removed for the attacked and it's party/group only) \todo Needs more documentation
    PASSIVE               = 0x00000200,           ///< makes you unable to attack everything. Almost identical to our "civilian"-term. Will ignore it's surroundings and not engage in combat unless "called upon" or engaged by another unit.
    PVP                   = 0x00001000,
    SILENCED              = 0x00002000,           ///< silenced, 2.1.1
    UNK_14                = 0x00004000,           ///< 2.0.8
    UNK_15                = 0x00008000,           ///< related to jerky movement in water?
    UNK_16                = 0x00010000,           ///< removes attackable icon
    PACIFIED              = 0x00020000,
    DISABLE_ROTATE        = 0x00040000,
    IN_COMBAT             = 0x00080000,
    NOT_SELECTABLE        = 0x02000000,
    SKINNABLE             = 0x04000000,
    AURAS_VISIBLE         = 0x08000000,           ///< magic detect
    SHEATHE               = 0x40000000,
    // UNK_31              = 0x80000000           // no affect in 1.12.1

    NOT_ATTACKABLE_1      = 0x00000080,           ///< ?? (PVP_ATTACKABLE | NOT_ATTACKABLE_1) is NON_PVP_ATTACKABLE
    LOOTING               = 0x00000400,           ///< loot animation
    PET_IN_COMBAT         = 0x00000800,           ///< in combat?, 2.0.8
    STUNNED               = 0x00040000,           ///< stunned, 2.1.1
    TAXI_FLIGHT           = 0x00100000,           ///< disable casting at client side spell not allowed by taxi flight (mounted?), probably used with 0x4 flag
    DISARMED              = 0x00200000,           ///< disable melee spells casting..., "Required melee weapon" added to melee spells tooltip.
    CONFUSED              = 0x00400000,
    FLEEING               = 0x00800000,
    POSSESSED             = 0x01000000,           ///< used in spell Eyes of the Beast for pet... let attack by controlled creature |// Unit is under remote control by another unit, movement checks disabled, paired with loss of client control packet. New master is allowed to use melee attack and can't select this unit via mouse in the world (as if it was own character).
    UNK_28                = 0x10000000,
    UNK_29                = 0x20000000            ///< used in Feign Death spell
}