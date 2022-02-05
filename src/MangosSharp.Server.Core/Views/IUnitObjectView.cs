using System;
using System.Collections.Concurrent;
using MangosSharp.Core;
using MangosSharp.Server.Core.Enums;

namespace MangosSharp.Server.Core.Views;

public interface IUnitObjectView : IObjectView
{
    ObjectGuid Charm { get; set; }

    ObjectGuid Summon { get; set; }

    ObjectGuid CharmedBy { get; set; }

    ObjectGuid SummonedBy { get; set; }

    ObjectGuid CreatedBy { get; set; }

    ObjectGuid Target { get; set; }

    ObjectGuid Persuaded { get; set; }

    ObjectGuid ChannelObject { get; set; }

    int Health { get; set; }

    Span<int> Powers { get; }

    int MaxHealth { get; set; }

    Span<int> MaxPowers { get; }

    int Level { get; set; }

    int FactionTemplate { get; set; }

    byte Race { get; set; }
    
    byte Class { get; set; }
    
    Gender Gender { get; set; }
    
    PowerType PowerType { get; set; }

    Span<int> VirtualItemSlotDisplay { get; }

    Span<int> VirtualItemInfo { get; }

    UnitFlags UnitFlags { get; set; }

    Span<int> Auras { get; }

    Span<int> AuraFlags { get; }

    Span<int> AuraLevels { get; }

    Span<int> AuraApplications { get; }

    int AuraState { get; set; }

    int MainAttackTime { get; set; }

    int OffAttackTime { get; set; }

    int RangedAttackTime { get; set; }

    float BoundingRadius { get; set; }

    float CombatReach { get; set; }

    int DisplayId { get; set; }

    int NativeDisplayId { get; set; }

    int MountDisplayId { get; set; }

    float MinMainDamage { get; set; }

    float MaxMainDamage { get; set; }

    float MinOffDamage { get; set; }

    float MaxOffDamage { get; set; }

    UnitStandStateType StandState { get; set; }
    
    byte UnitFieldByte1_2 { get; set; }
    
    ShapeShiftForm ShapeShiftForm { get; set; }

    int PetNumber { get; set; }

    int PetNameTimestamp { get; set; }

    int PetExperience { get; set; }

    int PetNextLevelExperience { get; set; }

    int DynFlags { get; set; }

    int ChannelSpell { get; set; }

    int ModCastSpeed { get; set; }

    int CreatedBySpell { get; set; }

    int NpcFlags { get; set; }

    int NpcEmoteState { get; set; }

    Span<short> TrainingPoints { get; }

    Span<int> Stats { get; }

    Span<int> Resistances { get; }

    int BaseMana { get; set; }

    int BaseHealth { get; set; }

    SheathState SheathState { get; set; }
    
    UnitFlags2 UnitFlags2 { get; set; }

    Span<short> MeleeAttackPowerModifiers { get; }

    float MeleeAttackPowerMultiplier { get; set; }

    int RangedAttackPower { get; set; }

    Span<short> RangedAttackPowerModifiers { get; }

    float RangedAttackPowerMultiplier { get; set; }

    float MinRangedDamage { get; set; }

    float MaxRangedDamage { get; set; }

    Span<int> PowerCostModifiers { get; }

    Span<int> PowerCostMultipliers { get; }
    
    // server only
    
    int TemplateId { get; set; }
    
    UnitState UnitState { get; set; }
    
    string Name { get; set; }
    
    string SubName { get; set; }
    
    int Civilian { get; set; }
    
    int RacialLeader { get; set; }
    
    int Rank { get; set; }
    
    CreatureTypeFlags CreatureTypeFlags { get; set; }
    
    int CreatureTypeId { get; set; }
    
    ConcurrentDictionary<ObjectGuid, int> ThreatGuids { get; }
}