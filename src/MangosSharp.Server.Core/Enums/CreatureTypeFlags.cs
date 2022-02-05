namespace MangosSharp.Server.Core.Enums;

public enum CreatureTypeFlags
{
    TAMEABLE         = 0x00000001,       // Tameable by any hunter
    GHOST_VISIBLE    = 0x00000002,       // Creatures which can _also_ be seen when player is a ghost, used in CanInteract function by client, can't be attacked
    UNK3             = 0x00000004,       // "BOSS" flag for tooltips
    UNK4             = 0x00000008,
    UNK5             = 0x00000010,       // controls something in client tooltip related to creature faction
    UNK6             = 0x00000020,       // may be sound related
    UNK7             = 0x00000040,       // may be related to attackable / not attackable creatures with spells, used together with lua_IsHelpfulSpell/lua_IsHarmfulSpell
    UNK8             = 0x00000080,       // has something to do with unit interaction / quest status requests
    HERBLOOT         = 0x00000100,       // Can be looted by herbalist
    MININGLOOT       = 0x00000200,       // Can be looted by miner
    UNK11            = 0x00000400,       // no idea, but it used by client
    UNK12            = 0x00000800,       // related to possibility to cast spells while mounted
    CAN_ASSIST       = 0x00001000,       // Can aid any player (and group) in combat. Typically seen for escorting NPC's
    UNK14            = 0x00002000,       // checked from calls in Lua_PetHasActionBar
    UNK15            = 0x00004000,       // Lua_UnitGUID, client does guid_low &= 0xFF000000 if this flag is set
    ENGINEERLOOT     = 0x00008000,       // Can be looted by engineer    
}