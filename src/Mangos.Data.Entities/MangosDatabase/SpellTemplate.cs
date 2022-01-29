using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("spell_template")]
public class SpellTemplate
{
    [Column("Id", TypeName="int")]
    public virtual uint Id { get; set; }

    [Column("School", TypeName="int")]
    public virtual uint School { get; set; }

    [Column("Category", TypeName="int")]
    public virtual uint Category { get; set; }

    [Column("CastUI", TypeName="int")]
    public virtual uint CastUi { get; set; }

    [Column("Dispel", TypeName="int")]
    public virtual uint Dispel { get; set; }

    [Column("Mechanic", TypeName="int")]
    public virtual uint Mechanic { get; set; }

    [Column("Attributes", TypeName="int")]
    public virtual uint Attributes { get; set; }

    [Column("AttributesEx", TypeName="int")]
    public virtual uint AttributesEx { get; set; }

    [Column("AttributesEx2", TypeName="int")]
    public virtual uint AttributesEx2 { get; set; }

    [Column("AttributesEx3", TypeName="int")]
    public virtual uint AttributesEx3 { get; set; }

    [Column("AttributesEx4", TypeName="int")]
    public virtual uint AttributesEx4 { get; set; }

    [Column("Stances", TypeName="int")]
    public virtual uint Stances { get; set; }

    [Column("StancesNot", TypeName="int")]
    public virtual uint StancesNot { get; set; }

    [Column("Targets", TypeName="int")]
    public virtual uint Targets { get; set; }

    [Column("TargetCreatureType", TypeName="int")]
    public virtual uint TargetCreatureType { get; set; }

    [Column("RequiresSpellFocus", TypeName="int")]
    public virtual uint RequiresSpellFocus { get; set; }

    [Column("CasterAuraState", TypeName="int")]
    public virtual uint CasterAuraState { get; set; }

    [Column("TargetAuraState", TypeName="int")]
    public virtual uint TargetAuraState { get; set; }

    [Column("CastingTimeIndex", TypeName="int")]
    public virtual uint CastingTimeIndex { get; set; }

    [Column("RecoveryTime", TypeName="int")]
    public virtual uint RecoveryTime { get; set; }

    [Column("CategoryRecoveryTime", TypeName="int")]
    public virtual uint CategoryRecoveryTime { get; set; }

    [Column("InterruptFlags", TypeName="int")]
    public virtual uint InterruptFlags { get; set; }

    [Column("AuraInterruptFlags", TypeName="int")]
    public virtual uint AuraInterruptFlags { get; set; }

    [Column("ChannelInterruptFlags", TypeName="int")]
    public virtual uint ChannelInterruptFlags { get; set; }

    [Column("ProcFlags", TypeName="int")]
    public virtual uint ProcFlags { get; set; }

    [Column("ProcChance", TypeName="int")]
    public virtual uint ProcChance { get; set; }

    [Column("ProcCharges", TypeName="int")]
    public virtual uint ProcCharges { get; set; }

    [Column("MaxLevel", TypeName="int")]
    public virtual uint MaxLevel { get; set; }

    [Column("BaseLevel", TypeName="int")]
    public virtual uint BaseLevel { get; set; }

    [Column("SpellLevel", TypeName="int")]
    public virtual uint SpellLevel { get; set; }

    [Column("DurationIndex", TypeName="int")]
    public virtual uint DurationIndex { get; set; }

    [Column("PowerType", TypeName="int")]
    public virtual uint PowerType { get; set; }

    [Column("ManaCost", TypeName="int")]
    public virtual uint ManaCost { get; set; }

    [Column("ManaCostPerlevel", TypeName="int")]
    public virtual uint ManaCostPerlevel { get; set; }

    [Column("ManaPerSecond", TypeName="int")]
    public virtual uint ManaPerSecond { get; set; }

    [Column("ManaPerSecondPerLevel", TypeName="int")]
    public virtual uint ManaPerSecondPerLevel { get; set; }

    [Column("RangeIndex", TypeName="int")]
    public virtual uint RangeIndex { get; set; }

    [Column("Speed", TypeName="float")]
    public virtual float Speed { get; set; }

    [Column("ModalNextSpell", TypeName="int")]
    public virtual uint ModalNextSpell { get; set; }

    [Column("StackAmount", TypeName="int")]
    public virtual uint StackAmount { get; set; }

    [Column("Totem1", TypeName="int")]
    public virtual uint Totem1 { get; set; }

    [Column("Totem2", TypeName="int")]
    public virtual uint Totem2 { get; set; }

    [Column("Reagent1", TypeName="int")]
    public virtual int Reagent1 { get; set; }

    [Column("Reagent2", TypeName="int")]
    public virtual int Reagent2 { get; set; }

    [Column("Reagent3", TypeName="int")]
    public virtual int Reagent3 { get; set; }

    [Column("Reagent4", TypeName="int")]
    public virtual int Reagent4 { get; set; }

    [Column("Reagent5", TypeName="int")]
    public virtual int Reagent5 { get; set; }

    [Column("Reagent6", TypeName="int")]
    public virtual int Reagent6 { get; set; }

    [Column("Reagent7", TypeName="int")]
    public virtual int Reagent7 { get; set; }

    [Column("Reagent8", TypeName="int")]
    public virtual int Reagent8 { get; set; }

    [Column("ReagentCount1", TypeName="int")]
    public virtual uint ReagentCount1 { get; set; }

    [Column("ReagentCount2", TypeName="int")]
    public virtual uint ReagentCount2 { get; set; }

    [Column("ReagentCount3", TypeName="int")]
    public virtual uint ReagentCount3 { get; set; }

    [Column("ReagentCount4", TypeName="int")]
    public virtual uint ReagentCount4 { get; set; }

    [Column("ReagentCount5", TypeName="int")]
    public virtual uint ReagentCount5 { get; set; }

    [Column("ReagentCount6", TypeName="int")]
    public virtual uint ReagentCount6 { get; set; }

    [Column("ReagentCount7", TypeName="int")]
    public virtual uint ReagentCount7 { get; set; }

    [Column("ReagentCount8", TypeName="int")]
    public virtual uint ReagentCount8 { get; set; }

    [Column("EquippedItemClass", TypeName="int")]
    public virtual int EquippedItemClass { get; set; }

    [Column("EquippedItemSubClassMask", TypeName="int")]
    public virtual int EquippedItemSubClassMask { get; set; }

    [Column("EquippedItemInventoryTypeMask", TypeName="int")]
    public virtual int EquippedItemInventoryTypeMask { get; set; }

    [Column("Effect1", TypeName="int")]
    public virtual uint Effect1 { get; set; }

    [Column("Effect2", TypeName="int")]
    public virtual uint Effect2 { get; set; }

    [Column("Effect3", TypeName="int")]
    public virtual uint Effect3 { get; set; }

    [Column("EffectDieSides1", TypeName="int")]
    public virtual int EffectDieSides1 { get; set; }

    [Column("EffectDieSides2", TypeName="int")]
    public virtual int EffectDieSides2 { get; set; }

    [Column("EffectDieSides3", TypeName="int")]
    public virtual int EffectDieSides3 { get; set; }

    [Column("EffectBaseDice1", TypeName="int")]
    public virtual uint EffectBaseDice1 { get; set; }

    [Column("EffectBaseDice2", TypeName="int")]
    public virtual uint EffectBaseDice2 { get; set; }

    [Column("EffectBaseDice3", TypeName="int")]
    public virtual uint EffectBaseDice3 { get; set; }

    [Column("EffectDicePerLevel1", TypeName="float")]
    public virtual float EffectDicePerLevel1 { get; set; }

    [Column("EffectDicePerLevel2", TypeName="float")]
    public virtual float EffectDicePerLevel2 { get; set; }

    [Column("EffectDicePerLevel3", TypeName="float")]
    public virtual float EffectDicePerLevel3 { get; set; }

    [Column("EffectRealPointsPerLevel1", TypeName="float")]
    public virtual float EffectRealPointsPerLevel1 { get; set; }

    [Column("EffectRealPointsPerLevel2", TypeName="float")]
    public virtual float EffectRealPointsPerLevel2 { get; set; }

    [Column("EffectRealPointsPerLevel3", TypeName="float")]
    public virtual float EffectRealPointsPerLevel3 { get; set; }

    [Column("EffectBasePoints1", TypeName="int")]
    public virtual int EffectBasePoints1 { get; set; }

    [Column("EffectBasePoints2", TypeName="int")]
    public virtual int EffectBasePoints2 { get; set; }

    [Column("EffectBasePoints3", TypeName="int")]
    public virtual int EffectBasePoints3 { get; set; }

    [Column("EffectMechanic1", TypeName="int")]
    public virtual uint EffectMechanic1 { get; set; }

    [Column("EffectMechanic2", TypeName="int")]
    public virtual uint EffectMechanic2 { get; set; }

    [Column("EffectMechanic3", TypeName="int")]
    public virtual uint EffectMechanic3 { get; set; }

    [Column("EffectImplicitTargetA1", TypeName="int")]
    public virtual uint EffectImplicitTargetA1 { get; set; }

    [Column("EffectImplicitTargetA2", TypeName="int")]
    public virtual uint EffectImplicitTargetA2 { get; set; }

    [Column("EffectImplicitTargetA3", TypeName="int")]
    public virtual uint EffectImplicitTargetA3 { get; set; }

    [Column("EffectImplicitTargetB1", TypeName="int")]
    public virtual uint EffectImplicitTargetB1 { get; set; }

    [Column("EffectImplicitTargetB2", TypeName="int")]
    public virtual uint EffectImplicitTargetB2 { get; set; }

    [Column("EffectImplicitTargetB3", TypeName="int")]
    public virtual uint EffectImplicitTargetB3 { get; set; }

    [Column("EffectRadiusIndex1", TypeName="int")]
    public virtual uint EffectRadiusIndex1 { get; set; }

    [Column("EffectRadiusIndex2", TypeName="int")]
    public virtual uint EffectRadiusIndex2 { get; set; }

    [Column("EffectRadiusIndex3", TypeName="int")]
    public virtual uint EffectRadiusIndex3 { get; set; }

    [Column("EffectApplyAuraName1", TypeName="int")]
    public virtual uint EffectApplyAuraName1 { get; set; }

    [Column("EffectApplyAuraName2", TypeName="int")]
    public virtual uint EffectApplyAuraName2 { get; set; }

    [Column("EffectApplyAuraName3", TypeName="int")]
    public virtual uint EffectApplyAuraName3 { get; set; }

    [Column("EffectAmplitude1", TypeName="int")]
    public virtual uint EffectAmplitude1 { get; set; }

    [Column("EffectAmplitude2", TypeName="int")]
    public virtual uint EffectAmplitude2 { get; set; }

    [Column("EffectAmplitude3", TypeName="int")]
    public virtual uint EffectAmplitude3 { get; set; }

    [Column("EffectMultipleValue1", TypeName="float")]
    public virtual float EffectMultipleValue1 { get; set; }

    [Column("EffectMultipleValue2", TypeName="float")]
    public virtual float EffectMultipleValue2 { get; set; }

    [Column("EffectMultipleValue3", TypeName="float")]
    public virtual float EffectMultipleValue3 { get; set; }

    [Column("EffectChainTarget1", TypeName="int")]
    public virtual uint EffectChainTarget1 { get; set; }

    [Column("EffectChainTarget2", TypeName="int")]
    public virtual uint EffectChainTarget2 { get; set; }

    [Column("EffectChainTarget3", TypeName="int")]
    public virtual uint EffectChainTarget3 { get; set; }

    [Column("EffectItemType1", TypeName="int")]
    public virtual uint EffectItemType1 { get; set; }

    [Column("EffectItemType2", TypeName="int")]
    public virtual uint EffectItemType2 { get; set; }

    [Column("EffectItemType3", TypeName="int")]
    public virtual uint EffectItemType3 { get; set; }

    [Column("EffectMiscValue1", TypeName="int")]
    public virtual int EffectMiscValue1 { get; set; }

    [Column("EffectMiscValue2", TypeName="int")]
    public virtual int EffectMiscValue2 { get; set; }

    [Column("EffectMiscValue3", TypeName="int")]
    public virtual int EffectMiscValue3 { get; set; }

    [Column("EffectTriggerSpell1", TypeName="int")]
    public virtual uint EffectTriggerSpell1 { get; set; }

    [Column("EffectTriggerSpell2", TypeName="int")]
    public virtual uint EffectTriggerSpell2 { get; set; }

    [Column("EffectTriggerSpell3", TypeName="int")]
    public virtual uint EffectTriggerSpell3 { get; set; }

    [Column("EffectPointsPerComboPoint1", TypeName="float")]
    public virtual float EffectPointsPerComboPoint1 { get; set; }

    [Column("EffectPointsPerComboPoint2", TypeName="float")]
    public virtual float EffectPointsPerComboPoint2 { get; set; }

    [Column("EffectPointsPerComboPoint3", TypeName="float")]
    public virtual float EffectPointsPerComboPoint3 { get; set; }

    [Column("SpellVisual", TypeName="int")]
    public virtual uint SpellVisual { get; set; }

    [Column("SpellIconID", TypeName="int")]
    public virtual uint SpellIconId { get; set; }

    [Column("ActiveIconID", TypeName="int")]
    public virtual uint ActiveIconId { get; set; }

    [Column("SpellPriority", TypeName="int")]
    public virtual uint SpellPriority { get; set; }

    [Column("SpellName", TypeName="text")]
    [MaxLength(65535)]
    public virtual string SpellName { get; set; }

    [Column("SpellName2", TypeName="text")]
    [MaxLength(65535)]
    public virtual string SpellName2 { get; set; }

    [Column("SpellName3", TypeName="text")]
    [MaxLength(65535)]
    public virtual string SpellName3 { get; set; }

    [Column("SpellName4", TypeName="text")]
    [MaxLength(65535)]
    public virtual string SpellName4 { get; set; }

    [Column("SpellName5", TypeName="text")]
    [MaxLength(65535)]
    public virtual string SpellName5 { get; set; }

    [Column("SpellName6", TypeName="text")]
    [MaxLength(65535)]
    public virtual string SpellName6 { get; set; }

    [Column("SpellName7", TypeName="text")]
    [MaxLength(65535)]
    public virtual string SpellName7 { get; set; }

    [Column("SpellName8", TypeName="text")]
    [MaxLength(65535)]
    public virtual string SpellName8 { get; set; }

    [Column("Rank1", TypeName="text")]
    [MaxLength(65535)]
    public virtual string Rank1 { get; set; }

    [Column("Rank2", TypeName="text")]
    [MaxLength(65535)]
    public virtual string Rank2 { get; set; }

    [Column("Rank3", TypeName="text")]
    [MaxLength(65535)]
    public virtual string Rank3 { get; set; }

    [Column("Rank4", TypeName="text")]
    [MaxLength(65535)]
    public virtual string Rank4 { get; set; }

    [Column("Rank5", TypeName="text")]
    [MaxLength(65535)]
    public virtual string Rank5 { get; set; }

    [Column("Rank6", TypeName="text")]
    [MaxLength(65535)]
    public virtual string Rank6 { get; set; }

    [Column("Rank7", TypeName="text")]
    [MaxLength(65535)]
    public virtual string Rank7 { get; set; }

    [Column("Rank8", TypeName="text")]
    [MaxLength(65535)]
    public virtual string Rank8 { get; set; }

    [Column("ManaCostPercentage", TypeName="int")]
    public virtual uint ManaCostPercentage { get; set; }

    [Column("StartRecoveryCategory", TypeName="int")]
    public virtual uint StartRecoveryCategory { get; set; }

    [Column("StartRecoveryTime", TypeName="int")]
    public virtual uint StartRecoveryTime { get; set; }

    [Column("MaxTargetLevel", TypeName="int")]
    public virtual uint MaxTargetLevel { get; set; }

    [Column("SpellFamilyName", TypeName="int")]
    public virtual uint SpellFamilyName { get; set; }

    [Column("SpellFamilyFlags", TypeName="bigint")]
    public virtual ulong SpellFamilyFlags { get; set; }

    [Column("MaxAffectedTargets", TypeName="int")]
    public virtual uint MaxAffectedTargets { get; set; }

    [Column("DmgClass", TypeName="int")]
    public virtual uint DmgClass { get; set; }

    [Column("PreventionType", TypeName="int")]
    public virtual uint PreventionType { get; set; }

    [Column("StanceBarOrder", TypeName="int")]
    public virtual int StanceBarOrder { get; set; }

    [Column("DmgMultiplier1", TypeName="float")]
    public virtual float DmgMultiplier1 { get; set; }

    [Column("DmgMultiplier2", TypeName="float")]
    public virtual float DmgMultiplier2 { get; set; }

    [Column("DmgMultiplier3", TypeName="float")]
    public virtual float DmgMultiplier3 { get; set; }

    [Column("MinFactionId", TypeName="int")]
    public virtual uint MinFactionId { get; set; }

    [Column("MinReputation", TypeName="int")]
    public virtual uint MinReputation { get; set; }

    [Column("RequiredAuraVision", TypeName="int")]
    public virtual uint RequiredAuraVision { get; set; }

    [Column("IsServerSide", TypeName="int")]
    public virtual uint IsServerSide { get; set; }

    [Column("AttributesServerside", TypeName="int")]
    public virtual uint AttributesServerside { get; set; }

}