using MangosSharp.Server.Core.Enums;

namespace MangosSharp.Server.Core.Views;

public interface IMovementView
{
    MovementFlags Flags { get; set; }

    int Timestamp { get; set; }

    ILocationView Location { get; }

    IMovementTransportView Transport { get; }

    float Pitch { get; set; }

    int FallTime { get; set; }

    IMovementJumpView Jump { get; }

    float SplineElevation { get; set; }
    
    bool MovingForward { get; set; }
    
    bool MovingBackward { get; set; }
    
    bool StrafingLeft { get; set; }
    
    bool StrafingRight { get; set; }
    
    bool TurningLeft { get; set; }
    
    bool TurningRight { get; set; }
    
    bool PitchingUp { get; set; }
    
    bool PitchingDown { get; set; }
    
    bool Walking { get; set; }
    
    bool Jumping { get; set; }
    
    bool Falling { get; set; }
    
    bool Swimming { get; set; }
    
    bool OnTransport { get; set; }
    
    bool IsSplineMovement { get; set; }
}