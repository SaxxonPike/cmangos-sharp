namespace MangosSharp.Server.Core.Views;

public interface IMovementSpeedView
{
    float WalkSpeed { get; set; }
    float RunSpeed { get; set; }
    float RunBackSpeed { get; set; }
    float SwimSpeed { get; set; }
    float SwimBackSpeed { get; set; }
    float TurnSpeed { get; set; }
}