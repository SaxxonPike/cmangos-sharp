using System;
using MangosSharp.Core;
using MangosSharp.Server.Core.Enums;

namespace MangosSharp.Server.Core.Views;

public sealed class GameObjectView : ObjectView, IGameObjectView
{
    public GameObjectView() : this(new int[Fields.GAMEOBJECT_END])
    {
    }

    public GameObjectView(Memory<int> fields) : base(fields)
    {
        Location = new LocationView(RawFields.Slice(Fields.GAMEOBJECT_POS_X, 4));
        TypeMask |= TypeMask.GAMEOBJECT;
    }

    public ObjectGuid CreatedBy
    {
        get => GetLong(Fields.OBJECT_FIELD_CREATED_BY);
        set => SetLong(Fields.OBJECT_FIELD_CREATED_BY, value);
    }

    public int DisplayId
    {
        get => GetInt(Fields.GAMEOBJECT_DISPLAYID);
        set => SetInt(Fields.GAMEOBJECT_DISPLAYID, value);
    }

    public int Flags
    {
        get => GetInt(Fields.GAMEOBJECT_FLAGS);
        set => SetInt(Fields.GAMEOBJECT_FLAGS, value);
    }

    public Span<float> Rotations => GetFloats(Fields.GAMEOBJECT_ROTATION, 4);

    public int State
    {
        get => GetInt(Fields.GAMEOBJECT_STATE);
        set => SetInt(Fields.GAMEOBJECT_STATE, value);
    }

    public override ILocationView Location { get; }

    public int DynFlags
    {
        get => GetInt(Fields.GAMEOBJECT_DYN_FLAGS);
        set => SetInt(Fields.GAMEOBJECT_DYN_FLAGS, value);
    }

    public int Faction
    {
        get => GetInt(Fields.GAMEOBJECT_FACTION);
        set => SetInt(Fields.GAMEOBJECT_FACTION, value);
    }

    public GameObjectType Type
    {
        get => (GameObjectType)GetInt(Fields.GAMEOBJECT_TYPE_ID);
        set => SetInt(Fields.GAMEOBJECT_TYPE_ID, (int)value);
    }

    public int Level
    {
        get => GetInt(Fields.GAMEOBJECT_LEVEL);
        set => SetInt(Fields.GAMEOBJECT_LEVEL, value);
    }

    public int ArtKit
    {
        get => GetInt(Fields.GAMEOBJECT_ARTKIT);
        set => SetInt(Fields.GAMEOBJECT_ARTKIT, value);
    }

    public int AnimProgress
    {
        get => GetInt(Fields.GAMEOBJECT_ANIMPROGRESS);
        set => SetInt(Fields.GAMEOBJECT_ANIMPROGRESS, value);
    }

    // server side only

    public bool IsTransport => Type is GameObjectType.TRANSPORT or GameObjectType.MO_TRANSPORT;

    public override UpdateFlags UpdateFlags => UpdateFlags.ALL | UpdateFlags.HAS_POSITION;
}