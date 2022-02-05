using System;

namespace MangosSharp.Server.Core.Enums;

[Flags]
public enum UnitState
{
    // persistent state (applied by aura/etc until expire)
    MELEE_ATTACKING = 0x00000001, // unit is melee attacking someone Unit::Attack

    ATTACK_PLAYER =
        0x00000002, // unit attack player or player's controlled unit and have contested pvpv timer setup, until timer expire, combat end and etc
    DIED = 0x00000004, // Unit::SetFeignDeath
    STUNNED = 0x00000008, // Aura::HandleAuraModStun
    ROOT = 0x00000010, // Aura::HandleAuraModRoot
    ISOLATED = 0x00000020, // area auras do not affect other players, Aura::HandleAuraModSchoolImmunity
    CONTROLLED = 0x00000040, // Aura::HandleAuraModPossess

    // persistent movement generator state (all time while movement generator applied to unit (independent from top state of movegen)
    TAXI_FLIGHT =
        0x00000080, // player is in flight mode (in fact interrupted at far teleport until next map telport landing)
    DISTRACTED = 0x00000100, // DistractedMovementGenerator active

    // persistent movement generator state with non-persistent mirror states for stop support
    // (can be removed temporary by stop command or another movement generator apply)
    // not use _MOVE versions for generic movegen state, it can be removed temporary for unit stop and etc
    CONFUSED = 0x00000200, // ConfusedMovementGenerator active/onstack
    CONFUSED_MOVE = 0x00000400,
    ROAMING = 0x00000800, // RandomMovementGenerator/PointMovementGenerator/WaypointMovementGenerator active (now always set)
    ROAMING_MOVE = 0x00001000,
    CHASE = 0x00002000, // ChaseMovementGenerator active
    CHASE_MOVE = 0x00004000,
    FOLLOW = 0x00008000, // FollowMovementGenerator active
    FOLLOW_MOVE = 0x00010000,
    FLEEING = 0x00020000, // FleeMovementGenerator/TimedFleeingMovementGenerator active/onstack
    FLEEING_MOVE = 0x00040000,
    // More room for other MMGens

    // High-Level states (usually only with Creatures)
    NO_COMBAT_MOVEMENT = 0x01000000, // Combat Movement for MoveChase stopped
    RUNNING = 0x02000000, // SetRun for waypoints and such
    WAYPOINT_PAUSED = 0x04000000, // Waypoint-Movement paused genericly (ie by script)

    IGNORE_PATHFINDING = 0x10000000, // do not use pathfinding in any MovementGenerator

    // masks (only for check)

    // can't move currently
    CAN_NOT_MOVE = ROOT | STUNNED | DIED,

    // stay by different reasons
    NOT_MOVE = ROOT | STUNNED | DIED |
                         DISTRACTED,

    // stay or scripted movement for effect( = in player case you can't move by client command)
    NO_FREE_MOVE = ROOT | STUNNED | DIED |
                             TAXI_FLIGHT |
                             CONFUSED | FLEEING,

    // not react at move in sight or other
    CAN_NOT_REACT = STUNNED | DIED |
                              CONFUSED | FLEEING,

    // AI disabled by some reason
    LOST_CONTROL = CONFUSED | FLEEING | CONTROLLED,

    // above 2 state cases
    CAN_NOT_REACT_OR_LOST_CONTROL = CAN_NOT_REACT | LOST_CONTROL,

    // masks (for check or reset)

    // for real move using movegen check and stop (except unstoppable flight)
    MOVING = ROAMING_MOVE | CHASE_MOVE | FOLLOW_MOVE | FLEEING_MOVE,

    RUNNING_STATE = CHASE_MOVE | FLEEING_MOVE | RUNNING,

    ALL_STATE = -1,

    ALL_DYN_STATES = ALL_STATE & ~(NO_COMBAT_MOVEMENT | RUNNING |
                                                       WAYPOINT_PAUSED | IGNORE_PATHFINDING)
}