using System.Numerics;
using System.Runtime.InteropServices;

namespace MangosSharp.Server.Core.Views;

public interface ILocationView : IViewBase
{
    float X { get; set; }
    float Y { get; set; }
    float Z { get; set; }
    float A { get; set; }
}

public static class LocationViewExtensions
{
    public static float DistanceFrom2d(this ILocationView self, ILocationView other)
    {
        var a = new Vector2(MemoryMarshal.Cast<int, float>(self.RawFields.Span));
        var b = new Vector2(MemoryMarshal.Cast<int, float>(other.RawFields.Span));
        return Vector2.Distance(a, b);
    }

    public static float DistanceFrom3d(this ILocationView self, ILocationView other)
    {
        var a = new Vector3(MemoryMarshal.Cast<int, float>(self.RawFields.Span));
        var b = new Vector3(MemoryMarshal.Cast<int, float>(other.RawFields.Span));
        return Vector3.Distance(a, b);
    }
}