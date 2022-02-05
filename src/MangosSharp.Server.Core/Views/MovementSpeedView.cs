using System;

namespace MangosSharp.Server.Core.Views;

public sealed class MovementSpeedView : ViewBase, IMovementSpeedView
{
    public MovementSpeedView() : this(new int[6])
    {
    }

    public MovementSpeedView(Memory<int> fields) : base(fields)
    {
    }

    public float WalkSpeed
    {
        get => GetFloat(0);
        set => SetFloat(0, value);
    }

    public float RunSpeed
    {
        get => GetFloat(1);
        set => SetFloat(1, value);
    }

    public float RunBackSpeed
    {
        get => GetFloat(2);
        set => SetFloat(2, value);
    }

    public float SwimSpeed
    {
        get => GetFloat(3);
        set => SetFloat(3, value);
    }

    public float SwimBackSpeed
    {
        get => GetFloat(4);
        set => SetFloat(4, value);
    }

    public float TurnSpeed
    {
        get => GetFloat(5);
        set => SetFloat(5, value);
    }
}