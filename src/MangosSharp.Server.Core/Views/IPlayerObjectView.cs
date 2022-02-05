using System;
using System.Collections.Generic;
using MangosSharp.Core;
using MangosSharp.Server.Core.Enums;

namespace MangosSharp.Server.Core.Views;

public interface IPlayerObjectView : IUnitObjectView
{
    ObjectGuid DuelArbiter { get; set; }

    PlayerFlags PlayerFlags { get; set; }

    int GuildId { get; set; }

    int GuildRank { get; set; }

    byte Skin { get; set; }
    
    byte Face { get; set; }
    
    byte HairStyle { get; set; }
    
    byte HairColor { get; set; }
    
    byte FacialHair { get; set; }
    
    short GenderPlusDrunk { get; set; }
    
    byte BattlefieldArenaFaction { get; set; }

    int DuelTeam { get; set; }

    int GuildTimestamp { get; set; }

    Span<int> QuestLog { get; }

    Span<int> VisibleItemRaw { get; }
    
    Span<long> ItemSlots { get; }

    // Span<long> BackpackItems { get; }
    //
    // Span<long> BankItems { get; }
    //
    // Span<long> BankBagItems { get; }
    //
    // Span<long> VendorBuybackItems { get; }
    //
    // Span<long> KeyringItems { get; }
    //
    ObjectGuid FarSight { get; set; }

    ObjectGuid FieldComboTarget { get; set; }

    int Experience { get; set; }

    int NextLevelExperience { get; set; }

    Span<short> Skills { get; }

    Span<int> Points { get; }

    int TrackCreatures { get; set; }

    int TrackResources { get; set; }

    float BlockPercentage { get; set; }

    float DodgePercentage { get; set; }

    float ParryPercentage { get; set; }

    float MeleeCriticalPercentage { get; set; }

    float RangedCriticalPercentage { get; set; }

    Span<byte> ExploredZones { get; }

    float RestExperience { get; set; }

    int Money { get; set; }

    Span<int> StatBonuses { get; }

    Span<int> StatPenalties { get; }

    Span<int> ResistanceBonuses { get; }

    Span<int> ResistancePenalties { get; }

    Span<int> SpellPowerBonuses { get; }

    Span<int> SpellPowerPenalties { get; }

    Span<int> SpellPowerPct { get; }

    PlayerFieldFlags PlayerFieldFlags { get; set; }
    
    byte ComboPoints { get; set; }
    
    byte ActionBarState { get; set; }

    int AmmoId { get; set; }

    int SelfResSpell { get; set; }

    int PvpMedals { get; set; }

    Span<int> VendorBuybackPrices { get; }

    Span<int> VendorBuybackTimestamps { get; }

    Span<short> KillsThisSession { get; }

    Span<short> KillsYesterday { get; }

    Span<short> KillsLastWeek { get; }

    Span<short> KillsThisWeek { get; }

    int ContributionThisWeek { get; set; }

    int LifetimeHonorableKills { get; set; }

    int LifetimeDishonorableKills { get; set; }

    int ContributionYesterday { get; set; }

    int ContributionLastWeek { get; set; }

    int HonorRank { get; set; }

    int WatchedFaction { get; set; }

    PlayerFieldByte2Flags PlayerFieldFlags2 { get; set; }

    Span<int> CombatRatings { get; }
    
    // not in mask
    
    string Ip { get; set; }
    
    string RealmName { get; set; }
    
    IDictionary<int, int> Reputations { get; }
    
    Team Team { get; set; }
}