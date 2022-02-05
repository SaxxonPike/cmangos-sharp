namespace MangosSharp.Server.Core.Views;

public interface IMovementJumpView
{
    float Velocity { get; set; }
    float SinAngle { get; set; }
    float CosAngle { get; set; }
    float XySpeed { get; set; }
}