using System;

namespace MangosSharp.Server.Core.Views;

public sealed class MovementJumpView : ViewBase, IMovementJumpView
{
    public MovementJumpView() : this(new int[4])
    {
    }

    public MovementJumpView(Memory<int> fields) : base(fields)
    {
    }

    public float Velocity
    {
        get => GetFloat(0);
        set => SetFloat(0, value);
    }

    public float SinAngle
    {
        get => GetFloat(1);
        set => SetFloat(1, value);
    }

    public float CosAngle
    {
        get => GetFloat(2);
        set => SetFloat(2, value);
    }

    public float XySpeed
    {
        get => GetFloat(3);
        set => SetFloat(3, value);
    }
}