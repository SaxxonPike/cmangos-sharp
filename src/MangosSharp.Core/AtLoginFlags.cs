using System;

namespace MangosSharp.Core;

[Flags]
public enum AtLoginFlags
{
    AT_LOGIN_NONE                 = 0x00,
    AT_LOGIN_RENAME               = 0x01,
    AT_LOGIN_RESET_SPELLS         = 0x02,
    AT_LOGIN_RESET_TALENTS        = 0x04,
    // AT_LOGIN_CUSTOMIZE         = 0x08, -- used in post-3.x
    // AT_LOGIN_RESET_PET_TALENTS = 0x10, -- used in post-3.x
    AT_LOGIN_FIRST                = 0x20,
    AT_LOGIN_RESET_TAXINODES      = 0x40,
    AT_LOGIN_ADD_BG_DESERTER      = 0x80
}