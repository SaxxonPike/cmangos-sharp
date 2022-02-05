using System;
using System.Collections.Generic;
using MangosSharp.Core;
using MangosSharp.Server.Core.Enums;

namespace MangosSharp.Server.Core.Views;

public sealed class PlayerObjectView : UnitObjectView, IPlayerObjectView
{
    public PlayerObjectView() : this(new int[Fields.PLAYER_END])
    {
    }

    public PlayerObjectView(Memory<int> fields) : base(fields)
    {
        TypeMask |= TypeMask.PLAYER;
    }

    public ObjectGuid DuelArbiter
    {
        get => GetLong(Fields.PLAYER_DUEL_ARBITER);
        set => SetLong(Fields.PLAYER_DUEL_ARBITER, value);
    }

    public PlayerFlags PlayerFlags
    {
        get => (PlayerFlags)GetInt(Fields.PLAYER_FLAGS);
        set => SetInt(Fields.PLAYER_FLAGS, (int)value);
    }

    public int GuildId
    {
        get => GetInt(Fields.PLAYER_GUILDID);
        set => SetInt(Fields.PLAYER_GUILDID, value);
    }

    public int GuildRank
    {
        get => GetInt(Fields.PLAYER_GUILDRANK);
        set => SetInt(Fields.PLAYER_GUILDRANK, value);
    }

    public byte Skin
    {
        get => GetByte(Fields.PLAYER_BYTES, 0);
        set => SetByte(Fields.PLAYER_BYTES, 0, value);
    }

    public byte Face
    {
        get => GetByte(Fields.PLAYER_BYTES, 1);
        set => SetByte(Fields.PLAYER_BYTES, 1, value);
    }

    public byte HairStyle
    {
        get => GetByte(Fields.PLAYER_BYTES, 2);
        set => SetByte(Fields.PLAYER_BYTES, 2, value);
    }

    public byte HairColor
    {
        get => GetByte(Fields.PLAYER_BYTES, 3);
        set => SetByte(Fields.PLAYER_BYTES, 3, value);
    }

    public byte FacialHair
    {
        get => GetByte(Fields.PLAYER_BYTES_2, 0);
        set => SetByte(Fields.PLAYER_BYTES_2, 0, value);
    }

    public short GenderPlusDrunk
    {
        get => GetShorts(Fields.PLAYER_BYTES_3, 1)[0];
        set => GetShorts(Fields.PLAYER_BYTES_3, 1)[0] = value;
    }

    public byte BattlefieldArenaFaction
    {
        get => GetByte(Fields.PLAYER_BYTES_3, 3);
        set => SetByte(Fields.PLAYER_BYTES_3, 3, value);
    }

    public int DuelTeam
    {
        get => GetInt(Fields.PLAYER_DUEL_TEAM);
        set => SetInt(Fields.PLAYER_DUEL_TEAM, value);
    }

    public int GuildTimestamp
    {
        get => GetInt(Fields.PLAYER_GUILD_TIMESTAMP);
        set => SetInt(Fields.PLAYER_GUILD_TIMESTAMP, value);
    }

    // 20 quests, 3 fields per
    public Span<int> QuestLog => GetInts(Fields.PLAYER_QUEST_LOG_1_1, 20 * 3);

    // 19 equipment slots, 12 fields per
    public Span<int> VisibleItemRaw => GetInts(Fields.PLAYER_VISIBLE_ITEM_1_CREATOR, 19 * 12);

    // 23 inventory slots for equipment (yes this is different), 2 fields per
    public Span<long> ItemSlots => GetLongs(Fields.PLAYER_FIELD_INV_SLOT_HEAD, 23 + 16 + 24 + 6 + 12 + 32);

    // // 16 backpack slots, 2 fields per
    // public Span<long> BackpackItems => GetLongs(Fields.PLAYER_FIELD_PACK_SLOT_1, 16);
    //
    // // 24 bank slots, 2 fields per
    // public Span<long> BankItems => GetLongs(Fields.PLAYER_FIELD_BANK_SLOT_1, 24);
    //
    // // 6 bank bag slots, 2 fields per
    // public Span<long> BankBagItems => GetLongs(Fields.PLAYER_FIELD_BANKBAG_SLOT_1, 6);
    //
    // // 12 vendor buyback slots, 2 fields per
    // public Span<long> VendorBuybackItems => GetLongs(Fields.PLAYER_FIELD_VENDORBUYBACK_SLOT_1, 12);
    //
    // // 32 keyring slots, 2 fields per
    // public Span<long> KeyringItems => GetLongs(Fields.PLAYER_FIELD_KEYRING_SLOT_1, 32);

    public ObjectGuid FarSight
    {
        get => GetLong(Fields.PLAYER_FARSIGHT);
        set => SetLong(Fields.PLAYER_FARSIGHT, value);
    }

    public ObjectGuid FieldComboTarget
    {
        get => GetLong(Fields.PLAYER_FIELD_COMBO_TARGET);
        set => SetLong(Fields.PLAYER_FIELD_COMBO_TARGET, value);
    }

    public int Experience
    {
        get => GetInt(Fields.PLAYER_XP);
        set => SetInt(Fields.PLAYER_XP, value);
    }

    public int NextLevelExperience
    {
        get => GetInt(Fields.PLAYER_NEXT_LEVEL_XP);
        set => SetInt(Fields.PLAYER_NEXT_LEVEL_XP, value);
    }

    public Span<short> Skills => GetShorts(Fields.PLAYER_SKILL_INFO_1_1, 384);

    public Span<int> Points => GetInts(Fields.PLAYER_CHARACTER_POINTS1, 2);

    public int TrackCreatures
    {
        get => GetInt(Fields.PLAYER_TRACK_CREATURES);
        set => SetInt(Fields.PLAYER_TRACK_CREATURES, value);
    }

    public int TrackResources
    {
        get => GetInt(Fields.PLAYER_TRACK_RESOURCES);
        set => SetInt(Fields.PLAYER_TRACK_RESOURCES, value);
    }

    public float BlockPercentage
    {
        get => GetFloat(Fields.PLAYER_BLOCK_PERCENTAGE);
        set => SetFloat(Fields.PLAYER_BLOCK_PERCENTAGE, value);
    }

    public float DodgePercentage
    {
        get => GetFloat(Fields.PLAYER_DODGE_PERCENTAGE);
        set => SetFloat(Fields.PLAYER_DODGE_PERCENTAGE, value);
    }

    public float ParryPercentage
    {
        get => GetFloat(Fields.PLAYER_PARRY_PERCENTAGE);
        set => SetFloat(Fields.PLAYER_PARRY_PERCENTAGE, value);
    }

    public float MeleeCriticalPercentage
    {
        get => GetFloat(Fields.PLAYER_CRIT_PERCENTAGE);
        set => SetFloat(Fields.PLAYER_CRIT_PERCENTAGE, value);
    }

    public float RangedCriticalPercentage
    {
        get => GetFloat(Fields.PLAYER_RANGED_CRIT_PERCENTAGE);
        set => SetFloat(Fields.PLAYER_RANGED_CRIT_PERCENTAGE, value);
    }

    public Span<byte> ExploredZones => GetBytes(Fields.PLAYER_EXPLORED_ZONES_1, 64);

    public float RestExperience
    {
        get => GetFloat(Fields.PLAYER_REST_STATE_EXPERIENCE);
        set => SetFloat(Fields.PLAYER_REST_STATE_EXPERIENCE, value);
    }

    public int Money
    {
        get => GetInt(Fields.PLAYER_FIELD_COINAGE);
        set => SetInt(Fields.PLAYER_FIELD_COINAGE, value);
    }

    public Span<int> StatBonuses => GetInts(Fields.PLAYER_FIELD_POSSTAT0, 5);

    public Span<int> StatPenalties => GetInts(Fields.PLAYER_FIELD_NEGSTAT0, 5);

    public Span<int> ResistanceBonuses => GetInts(Fields.PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE, 7);

    public Span<int> ResistancePenalties => GetInts(Fields.PLAYER_FIELD_RESISTANCEBUFFMODSNEGATIVE, 7);

    public Span<int> SpellPowerBonuses => GetInts(Fields.PLAYER_FIELD_MOD_DAMAGE_DONE_POS, 7);

    public Span<int> SpellPowerPenalties => GetInts(Fields.PLAYER_FIELD_MOD_DAMAGE_DONE_NEG, 7);

    public Span<int> SpellPowerPct => GetInts(Fields.PLAYER_FIELD_MOD_DAMAGE_DONE_PCT, 7);

    public PlayerFieldFlags PlayerFieldFlags
    {
        get => (PlayerFieldFlags)GetByte(Fields.PLAYER_FIELD_BYTES, 0);
        set => SetByte(Fields.PLAYER_FIELD_BYTES, 0, (byte)value);
    }

    public byte ComboPoints
    {
        get => GetByte(Fields.PLAYER_FIELD_BYTES, 1);
        set => SetByte(Fields.PLAYER_FIELD_BYTES, 1, value);
    }

    public byte ActionBarState
    {
        get => GetByte(Fields.PLAYER_FIELD_BYTES, 2);
        set => SetByte(Fields.PLAYER_FIELD_BYTES, 2, value);
    }

    public int AmmoId
    {
        get => GetInt(Fields.PLAYER_AMMO_ID);
        set => SetInt(Fields.PLAYER_AMMO_ID, value);
    }

    public int SelfResSpell
    {
        get => GetInt(Fields.PLAYER_SELF_RES_SPELL);
        set => SetInt(Fields.PLAYER_SELF_RES_SPELL, value);
    }

    public int PvpMedals
    {
        get => GetInt(Fields.PLAYER_FIELD_PVP_MEDALS);
        set => SetInt(Fields.PLAYER_FIELD_PVP_MEDALS, value);
    }

    public Span<int> VendorBuybackPrices => GetInts(Fields.PLAYER_FIELD_BUYBACK_PRICE_1, 12);

    public Span<int> VendorBuybackTimestamps => GetInts(Fields.PLAYER_FIELD_BUYBACK_TIMESTAMP_1, 12);

    public Span<short> KillsThisSession => GetShorts(Fields.PLAYER_FIELD_SESSION_KILLS, 1);

    public Span<short> KillsYesterday => GetShorts(Fields.PLAYER_FIELD_YESTERDAY_KILLS, 1);

    public Span<short> KillsLastWeek => GetShorts(Fields.PLAYER_FIELD_LAST_WEEK_KILLS, 1);

    public Span<short> KillsThisWeek => GetShorts(Fields.PLAYER_FIELD_THIS_WEEK_KILLS, 1);

    public int ContributionThisWeek
    {
        get => GetInt(Fields.PLAYER_FIELD_THIS_WEEK_CONTRIBUTION);
        set => SetInt(Fields.PLAYER_FIELD_THIS_WEEK_CONTRIBUTION, value);
    }

    public int LifetimeHonorableKills
    {
        get => GetInt(Fields.PLAYER_FIELD_LIFETIME_HONORBALE_KILLS);
        set => SetInt(Fields.PLAYER_FIELD_LIFETIME_HONORBALE_KILLS, value);
    }

    public int LifetimeDishonorableKills
    {
        get => GetInt(Fields.PLAYER_FIELD_LIFETIME_DISHONORBALE_KILLS);
        set => SetInt(Fields.PLAYER_FIELD_LIFETIME_DISHONORBALE_KILLS, value);
    }

    public int ContributionYesterday
    {
        get => GetInt(Fields.PLAYER_FIELD_YESTERDAY_CONTRIBUTION);
        set => SetInt(Fields.PLAYER_FIELD_YESTERDAY_CONTRIBUTION, value);
    }

    public int ContributionLastWeek
    {
        get => GetInt(Fields.PLAYER_FIELD_LAST_WEEK_CONTRIBUTION);
        set => SetInt(Fields.PLAYER_FIELD_LAST_WEEK_CONTRIBUTION, value);
    }

    public int HonorRank
    {
        get => GetInt(Fields.PLAYER_FIELD_LAST_WEEK_RANK);
        set => SetInt(Fields.PLAYER_FIELD_LAST_WEEK_RANK, value);
    }

    public int WatchedFaction
    {
        get => GetInt(Fields.PLAYER_FIELD_WATCHED_FACTION_INDEX);
        set => SetInt(Fields.PLAYER_FIELD_WATCHED_FACTION_INDEX, value);
    }

    public PlayerFieldByte2Flags PlayerFieldFlags2
    {
        get => (PlayerFieldByte2Flags)GetByte(Fields.PLAYER_FIELD_BYTES2, 1);
        set => SetByte(Fields.PLAYER_FIELD_BYTES2, 1, (byte)value);
    }

    public Span<int> CombatRatings => GetInts(Fields.PLAYER_FIELD_COMBAT_RATING_1, 20);

    // These are not stored in packet data.

    public ObjectGuid CharacterGuid { get; set; }
    
    public string Ip { get; set; }
    
    public string RealmName { get; set; }

    public IDictionary<int, int> Reputations { get; } = new Dictionary<int, int>();
    
    public Team Team { get; set; }
}