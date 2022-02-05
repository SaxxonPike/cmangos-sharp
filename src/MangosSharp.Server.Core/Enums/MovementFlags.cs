using System;

namespace MangosSharp.Server.Core.Enums;

[Flags]
public enum MovementFlags
{
    // Byte 1 (Resets on Movement Key Press)
    MOVE_STOP                  = 0x00000000,
    MOVE_FORWARD               = 0x00000001,
    MOVE_BACKWARD              = 0x00000002,
    STRAFE_LEFT                = 0x00000004,
    STRAFE_RIGHT               = 0x00000008,
    TURN_LEFT                  = 0x00000010,
    TURN_RIGHT                 = 0x00000020,
    PITCH_UP                   = 0x00000040,
    PITCH_DOWN                 = 0x00000080,

    // Byte 2 (Resets on Situation Change)
    WALK                       = 0x00000100,
    TRANSPORT                  = 0x00000200,
    DISABLEGRAVITY             = 0x00000400,
    ROOTED                     = 0x00000800,
    FALLING                    = 0x00001000,
    FALLING_FAR                = 0x00002000,
    PENDING_STOP               = 0x00004000,
    PENDING_UNSTRAFE           = 0x00008000,

    // Byte 3 
    PENDING_FORWARD            = 0x00010000,
    PENDING_BACKWARD           = 0x00020000,
    PENDING_STRAFE_LEFT        = 0x00040000,
    PENDING_STRAFE_RIGHT       = 0x00080000,
    PENDING_ROOT               = 0x00100000,
    SWIMMING                   = 0x00200000,
    ASCENDING                  = 0x00400000,
    CAN_FLY                    = 0x00800000,

    // Byte 4 (Script Based Flags. Never reset, only turned on or off.)
    FLYING                     = 0x01000000,
    FLYING2                    = 0x02000000,
    SPLINE_ELEVATION           = 0x04000000,
    SPLINE_ENABLED             = 0x08000000,
    WATER_WALK                 = 0x10000000,
    FEATHER_FALL               = 0x20000000,
    HOVER                      = 0x40000000,
}
