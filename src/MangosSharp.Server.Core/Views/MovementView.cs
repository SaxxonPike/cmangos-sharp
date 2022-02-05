using System;
using MangosSharp.Server.Core.Enums;

namespace MangosSharp.Server.Core.Views;

public sealed class MovementView : ViewBase, IMovementView
{
    public MovementView() : this(new int[20])
    {
    }

    public MovementView(Memory<int> fields) : base(fields)
    {
        Location = new LocationView(RawFields.Slice(2, 4));
        Transport = new MovementTransportView(RawFields.Slice(6, 7));
        Jump = new MovementJumpView(RawFields.Slice(15, 4));
    }

    public MovementFlags Flags
    {
        get => (MovementFlags)GetInt(0);
        set => SetInt(0, (int)value);
    }

    public int Timestamp
    {
        get => GetInt(1);
        set => SetInt(1, value);
    }

    public ILocationView Location { get; }

    public IMovementTransportView Transport { get; }

    public float Pitch
    {
        get => GetFloat(13);
        set => SetFloat(13, value);
    }

    public int FallTime
    {
        get => GetInt(14);
        set => SetInt(14, value);
    }

    public IMovementJumpView Jump { get; }

    public float SplineElevation
    {
        get => GetFloat(19);
        set => SetFloat(19, value);
    }
    
    public bool MovingForward
    {
        get => GetBit(0, 0);
        set => SetBit(0, 0, value);
    }

    public bool MovingBackward
    {
        get => GetBit(0, 1);
        set => SetBit(0, 1, value);
    }

    public bool StrafingLeft
    {
        get => GetBit(0, 2);
        set => SetBit(0, 2, value);
    }

    public bool StrafingRight
    {
        get => GetBit(0, 3);
        set => SetBit(0, 3, value);
    }

    public bool TurningLeft
    {
        get => GetBit(0, 4);
        set => SetBit(0, 4, value);
    }

    public bool TurningRight
    {
        get => GetBit(0, 5);
        set => SetBit(0, 5, value);
    }

    public bool PitchingUp
    {
        get => GetBit(0, 6);
        set => SetBit(0, 6, value);
    }

    public bool PitchingDown
    {
        get => GetBit(0, 7);
        set => SetBit(0, 7, value);
    }

    public bool Walking
    {
        get => GetBit(0, 8);
        set => SetBit(0, 8, value);
    }

    public bool Jumping
    {
        get => GetBit(0, 13);
        set => SetBit(0, 13, value);
    }

    public bool Falling
    {
        get => GetBit(0, 14);
        set => SetBit(0, 14, value);
    }

    public bool Swimming
    {
        get => GetBit(0, 21);
        set => SetBit(0, 21, value);
    }

    public bool OnTransport
    {
        get => GetBit(0, 25);
        set => SetBit(0, 25, value);
    }

    public bool IsSplineMovement
    {
        get => GetBit(0, 26);
        set => SetBit(0, 26, value);
    }

    public void CopyTo(IMovementView other)
    {
        if (other is MovementView mv)
            RawFields.CopyTo(mv.RawFields);
        else
            throw new Exception("Not supported..yet");
    }
}