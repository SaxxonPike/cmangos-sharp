using System;
using MangosSharp.Core;
using MangosSharp.Server.Core.Enums;

namespace MangosSharp.Server.Core.Views;

public sealed class DynamicObjectView : ObjectView, IDynamicObjectView
{
    public DynamicObjectView() : this(new int[Fields.DYNAMICOBJECT_END])
    {
    }

    public DynamicObjectView(Memory<int> fields) : base(fields)
    {
        TypeMask |= TypeMask.DYNAMICOBJECT;
        Location = new LocationView(RawFields.Slice(Fields.DYNAMICOBJECT_POS_X, 4));
    }

    public ObjectGuid Caster
    {
        get => GetLong(Fields.DYNAMICOBJECT_CASTER);
        set => SetLong(Fields.DYNAMICOBJECT_CASTER, value);
    }
    
    public Span<byte> Bytes => GetBytes(Fields.DYNAMICOBJECT_BYTES, 4);

    public int SpellId
    {
        get => GetInt(Fields.DYNAMICOBJECT_SPELLID);
        set => SetInt(Fields.DYNAMICOBJECT_SPELLID, value);
    }
    
    public float Radius
    {
        get => GetFloat(Fields.DYNAMICOBJECT_RADIUS);
        set => SetFloat(Fields.DYNAMICOBJECT_RADIUS, value);
    }

    public override ILocationView Location { get; }

    public override UpdateFlags UpdateFlags => UpdateFlags.ALL | UpdateFlags.HAS_POSITION;
}