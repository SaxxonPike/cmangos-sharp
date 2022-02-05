using System;
using MangosSharp.Core;

namespace MangosSharp.Server.Core.Views;

public sealed class MovementTransportView : ViewBase, IMovementTransportView
{
    public MovementTransportView() : this(new int[7])
    {
    }

    public MovementTransportView(Memory<int> fields) : base(fields)
    {
        Location = new LocationView(RawFields.Slice(2, 4));
    }

    public ObjectGuid Guid
    {
        get => GetLong(0);
        set => SetLong(0, value);
    }

    public ILocationView Location { get; }

    public int Timestamp
    {
        get => GetInt(6);
        set => SetInt(6, value);
    }
}