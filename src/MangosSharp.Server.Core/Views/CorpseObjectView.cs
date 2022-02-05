using System;
using MangosSharp.Core;
using MangosSharp.Server.Core.Enums;

namespace MangosSharp.Server.Core.Views;

public sealed class CorpseObjectView : ObjectView, ICorpseObjectView
{
    public CorpseObjectView() : this(new int[Fields.CORPSE_END])
    {
    }

    public CorpseObjectView(Memory<int> fields) : base(fields)
    {
        TypeMask |= TypeMask.CORPSE;
        Location = new CorpseObjectLocationView(RawFields.Slice(Fields.CORPSE_FIELD_FACING, 4));
    }

    public override ObjectGuid Owner
    {
        get => GetLong(Fields.CORPSE_FIELD_OWNER);
        set => SetLong(Fields.CORPSE_FIELD_OWNER, value);
    }

    public override ILocationView Location { get; }

    public int DisplayId
    {
        get => GetInt(Fields.CORPSE_FIELD_DISPLAY_ID);
        set => SetInt(Fields.CORPSE_FIELD_DISPLAY_ID, value);
    }

    public Span<int> Items => GetInts(Fields.CORPSE_FIELD_ITEM, 19);

    public Span<byte> Appearance => GetBytes(Fields.CORPSE_FIELD_BYTES_1, 2);

    public int Guild
    {
        get => GetInt(Fields.CORPSE_FIELD_GUILD);
        set => SetInt(Fields.CORPSE_FIELD_GUILD, value);
    }

    public int Flags
    {
        get => GetInt(Fields.CORPSE_FIELD_FLAGS);
        set => SetInt(Fields.CORPSE_FIELD_FLAGS, value);
    }

    public int DynamicFlags
    {
        get => GetInt(Fields.CORPSE_FIELD_DYNAMIC_FLAGS);
        set => SetInt(Fields.CORPSE_FIELD_DYNAMIC_FLAGS, value);
    }

    public override UpdateFlags UpdateFlags => UpdateFlags.TRANSPORT | UpdateFlags.ALL | UpdateFlags.HAS_POSITION;
}