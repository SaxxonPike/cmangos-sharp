namespace MangosSharp.Server.Core.Enums;

public enum Team
{
    NONE = 0, // used when team value unknown or not set, 0 is also meaning that can be used !team check
    BOTH_ALLOWED = 0, // used when a check should evaluate true for both teams
    INVALID = 1, // used to invalidate some team depending checks (means not for both teams)
    HORDE = 67,
    ALLIANCE = 469,
}