using System;
using System.Linq;
using MangosSharp.Core;
using MangosSharp.Server.Core.Enums;

namespace MangosSharp.Server.Core.Views;

public static class PlayerObjectViewExtensions
{
    public static int? GetBaseSkillValue(this IPlayerObjectView player, int skillId) =>
        default;

    public static void SetItemSlot(this IPlayerObjectView player, EquipmentSlot slot, IItemObjectView item)
    {
        // Set the inventory item slot.
        var itemGuid = item == default
            ? 0
            : new ObjectGuid(HighGuid.ITEM, item.Guid.Entry, item.Guid.Counter);

        // This looks funny- it's correct; this is a span of longs
        player.ItemSlots[(int)slot] = itemGuid;
        var fieldIndex = Fields.PLAYER_FIELD_INV_SLOT_HEAD + ((int)slot << 1);
        player.Invalidate(fieldIndex);
        player.Invalidate(fieldIndex + 1);

        // Anything not worn does not have externally visible IDs.
        if (slot >= EquipmentSlot.INVENTORY_SLOT_BAG_1)
            return;

        // Set the "inspect" properties for the slot.
        var visBase = (int)slot * 12;
        if (item == default)
        {
            for (var i = 0; i < 12; i++)
                player.VisibleItemRaw[visBase + i] = 0;
        }
        else
        {
            var creator = item.Creator;
            player.VisibleItemRaw[visBase] = unchecked((int)creator);
            player.VisibleItemRaw[visBase + 1] = unchecked((int)(creator >> 32));
            player.VisibleItemRaw[visBase + 2] = item.Entry;
            player.VisibleItemRaw[visBase + 3] = item.Enchantments[0];
            player.VisibleItemRaw[visBase + 4] = item.Enchantments[1];
            // player.VisibleItemRaw[visBase + 5] = 0;
            // player.VisibleItemRaw[visBase + 6] = 0;
            // player.VisibleItemRaw[visBase + 7] = 0;
            // player.VisibleItemRaw[visBase + 8] = 0;
            // player.VisibleItemRaw[visBase + 9] = 0;
            player.VisibleItemRaw[visBase + 10] = item.RandomPropertiesId & short.MaxValue;
            player.VisibleItemRaw[visBase + 11] = item.PropertySeed;
        }
        
        var visIndex = Fields.PLAYER_VISIBLE_ITEM_1_CREATOR + (int)slot * 12;
        for (var i = 0; i < 12; i++)
            player.Invalidate(visIndex + i);
    }

    private static readonly Memory<int> InvalidateAppearanceFields = ViewBase.GenerateMask(
        new[]
            {
                Fields.OBJECT_FIELD_SCALE_X,
                Fields.UNIT_FIELD_CHARM,
                Fields.UNIT_FIELD_CHARM + 1,
                Fields.UNIT_FIELD_SUMMON,
                Fields.UNIT_FIELD_SUMMON + 1,
                Fields.UNIT_FIELD_CHARMEDBY,
                Fields.UNIT_FIELD_CHARMEDBY + 1,
                Fields.UNIT_FIELD_TARGET,
                Fields.UNIT_FIELD_TARGET + 1,
                Fields.UNIT_FIELD_CHANNEL_OBJECT,
                Fields.UNIT_FIELD_CHANNEL_OBJECT + 1,
                Fields.UNIT_FIELD_HEALTH,
                Fields.UNIT_FIELD_POWER1,
                Fields.UNIT_FIELD_POWER2,
                Fields.UNIT_FIELD_POWER3,
                Fields.UNIT_FIELD_POWER4,
                Fields.UNIT_FIELD_POWER5,
                Fields.UNIT_FIELD_MAXHEALTH,
                Fields.UNIT_FIELD_MAXPOWER1,
                Fields.UNIT_FIELD_MAXPOWER2,
                Fields.UNIT_FIELD_MAXPOWER3,
                Fields.UNIT_FIELD_MAXPOWER4,
                Fields.UNIT_FIELD_MAXPOWER5,
                Fields.UNIT_FIELD_LEVEL,
                Fields.UNIT_FIELD_FACTIONTEMPLATE,
                Fields.UNIT_FIELD_BYTES_0,
                Fields.UNIT_FIELD_FLAGS
            }.Concat(Enumerable.Range(Fields.UNIT_FIELD_AURA, 80))
            .Concat(new[]
            {
                Fields.UNIT_FIELD_BASEATTACKTIME,
                Fields.UNIT_FIELD_BASEATTACKTIME + 1,
                Fields.UNIT_FIELD_BOUNDINGRADIUS,
                Fields.UNIT_FIELD_COMBATREACH,
                Fields.UNIT_FIELD_DISPLAYID,
                Fields.UNIT_FIELD_NATIVEDISPLAYID,
                Fields.UNIT_FIELD_MOUNTDISPLAYID,
                Fields.UNIT_FIELD_BYTES_1,
                Fields.UNIT_FIELD_PETNUMBER,
                Fields.UNIT_FIELD_PET_NAME_TIMESTAMP,
                Fields.UNIT_DYNAMIC_FLAGS,
                Fields.UNIT_CHANNEL_SPELL,
                Fields.UNIT_MOD_CAST_SPEED,
                Fields.UNIT_FIELD_BYTES_2,
                Fields.PLAYER_DUEL_ARBITER,
                Fields.PLAYER_DUEL_ARBITER + 1,
                Fields.PLAYER_FLAGS,
                Fields.PLAYER_GUILDID,
                Fields.PLAYER_GUILDRANK,
                Fields.PLAYER_BYTES,
                Fields.PLAYER_BYTES_2,
                Fields.PLAYER_BYTES_3,
                Fields.PLAYER_DUEL_TEAM,
                Fields.PLAYER_GUILD_TIMESTAMP,
            }).Concat(Enumerable.Range(Fields.PLAYER_QUEST_LOG_1_1, 60))
            .Concat(Enumerable.Range(Fields.PLAYER_VISIBLE_ITEM_1_CREATOR, 228))
            .ToArray());

    public static void InvalidateAppearance(this IPlayerObjectView player) => 
        player.Invalidate(InvalidateAppearanceFields.Span);
}