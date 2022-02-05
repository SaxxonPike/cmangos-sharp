using System;
using MangosSharp.Core;
using MangosSharp.Server.Core.Enums;

namespace MangosSharp.Server.Core.Views;

public class ItemObjectView : ObjectView, IItemObjectView
{
    public ItemObjectView() : this(new int[Fields.ITEM_END])
    {
    }

    public ItemObjectView(Memory<int> fields) : base(fields)
    {
        TypeMask |= TypeMask.ITEM;
    }

    public override ObjectGuid Owner
    {
        get => GetLong(Fields.ITEM_FIELD_OWNER);
        set => SetLong(Fields.ITEM_FIELD_OWNER, value);
    }

    public ObjectGuid Contained
    {
        get => GetLong(Fields.ITEM_FIELD_CONTAINED);
        set => SetLong(Fields.ITEM_FIELD_CONTAINED, value);
    }

    public ObjectGuid Creator
    {
        get => GetLong(Fields.ITEM_FIELD_CREATOR);
        set => SetLong(Fields.ITEM_FIELD_CREATOR, value);
    }

    public ObjectGuid GiftCreator
    {
        get => GetLong(Fields.ITEM_FIELD_GIFTCREATOR);
        set => SetLong(Fields.ITEM_FIELD_GIFTCREATOR, value);
    }

    public int StackCount
    {
        get => GetInt(Fields.ITEM_FIELD_STACK_COUNT);
        set => SetInt(Fields.ITEM_FIELD_STACK_COUNT, value);
    }

    public int Duration
    {
        get => GetInt(Fields.ITEM_FIELD_DURATION);
        set => SetInt(Fields.ITEM_FIELD_DURATION, value);
    }

    public Span<int> SpellCharges => GetInts(Fields.ITEM_FIELD_SPELL_CHARGES, 5);

    public int ItemFlags
    {
        get => GetInt(Fields.ITEM_FIELD_FLAGS);
        set => SetInt(Fields.ITEM_FIELD_FLAGS, value);
    }

    public Span<int> Enchantments => GetInts(Fields.ITEM_FIELD_ENCHANTMENT, 21);

    public int PropertySeed
    {
        get => GetInt(Fields.ITEM_FIELD_PROPERTY_SEED);
        set => SetInt(Fields.ITEM_FIELD_PROPERTY_SEED, value);
    }

    public int RandomPropertiesId
    {
        get => GetInt(Fields.ITEM_FIELD_RANDOM_PROPERTIES_ID);
        set => SetInt(Fields.ITEM_FIELD_RANDOM_PROPERTIES_ID, value);
    }

    public int TextId
    {
        get => GetInt(Fields.ITEM_FIELD_ITEM_TEXT_ID);
        set => SetInt(Fields.ITEM_FIELD_ITEM_TEXT_ID, value);
    }

    public int Durability
    {
        get => GetInt(Fields.ITEM_FIELD_DURABILITY);
        set => SetInt(Fields.ITEM_FIELD_DURABILITY, value);
    }

    public int MaxDurability
    {
        get => GetInt(Fields.ITEM_FIELD_MAXDURABILITY);
        set => SetInt(Fields.ITEM_FIELD_MAXDURABILITY, value);
    }

    public override UpdateFlags UpdateFlags => UpdateFlags.ALL;
}