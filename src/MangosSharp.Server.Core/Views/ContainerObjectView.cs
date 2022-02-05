using System;
using MangosSharp.Server.Core.Enums;

namespace MangosSharp.Server.Core.Views;

public sealed class ContainerObjectView : ItemObjectView, IContainerObjectView
{
    public ContainerObjectView() : this(new int[Fields.CONTAINER_END])
    {
    }

    public ContainerObjectView(Memory<int> fields) : base(fields)
    {
        TypeMask |= TypeMask.CONTAINER;
    }

    public int Capacity
    {
        get => GetInt(Fields.CONTAINER_FIELD_NUM_SLOTS);
        set => SetInt(Fields.CONTAINER_FIELD_NUM_SLOTS, value);
    }

    public Span<long> Slots => GetLongs(Fields.CONTAINER_FIELD_SLOT_1, 36);
}