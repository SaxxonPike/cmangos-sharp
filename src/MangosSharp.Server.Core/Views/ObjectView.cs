using System;
using System.Collections.Generic;
using MangosSharp.Core;
using MangosSharp.Server.Core.Enums;

namespace MangosSharp.Server.Core.Views;

public class ObjectView : ViewBase, IObjectView
{
    public ObjectView() : this(new int[Fields.OBJECT_END])
    {
    }

    public ObjectView(Memory<int> fields) : base(fields)
    {
        TypeMask |= TypeMask.OBJECT;
    }

    public ObjectGuid Guid
    {
        get => GetLong(Fields.OBJECT_FIELD_GUID);
        set => SetLong(Fields.OBJECT_FIELD_GUID, value);
    }

    public TypeMask TypeMask
    {
        get => (TypeMask)GetInt(Fields.OBJECT_FIELD_TYPE);
        set => SetInt(Fields.OBJECT_FIELD_TYPE, (int)value);
    }

    public int Entry
    {
        get => GetInt(Fields.OBJECT_FIELD_ENTRY);
        set => SetInt(Fields.OBJECT_FIELD_ENTRY, value);
    }

    public float ScaleX
    {
        get => GetFloat(Fields.OBJECT_FIELD_SCALE_X);
        set => SetFloat(Fields.OBJECT_FIELD_SCALE_X, value);
    }

    // these fields are ephemeral and not saved anywhere (but may be serialized)

    public virtual UpdateFlags UpdateFlags => 0;

    public int OwnerAccount { get; set; }

    public virtual ObjectGuid Owner { get; set; }

    public virtual IMovementView Movement => default;

    public virtual ILocationView Location => default;

    public virtual IMovementSpeedView Speed => default;

    public int MapId { get; set; }

    public int AreaId { get; set; }

    public List<ObjectGuid> VisibleGuids { get; } = new();

    public TypeId TypeId => Guid.TypeId;

    private static readonly Memory<int> ResetMaskInternal = GenerateMask(
        Fields.OBJECT_FIELD_GUID,
        Fields.OBJECT_FIELD_GUID + 1,
        Fields.OBJECT_FIELD_TYPE
    );

    protected override ReadOnlySpan<int> ResetMask => ResetMaskInternal.Span;
}