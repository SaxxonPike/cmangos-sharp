using MangosSharp.Server.Core.Enums;

namespace MangosSharp.Server.Core.Views;

public static class UnitObjectViewExtensions
{
    public static bool IsStopped(this IUnitObjectView view) => !view.UnitState.HasFlag(UnitState.MOVING);
}