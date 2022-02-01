namespace MangosSharp.Data.Entities.ClientDatabase;

[DbcTable("Spell")]
public sealed class Spell
{
    [System.ComponentModel.DataAnnotations.Key] [DbcField(0)]
    public int Id { get; set; }
    
    [DbcField(1)]
    public int School { get; set; }
    
    [DbcField(2)]
    public int Category { get; set; }
    
    [DbcField(3, clientOnly: true)]
    public int CastUi { get; set; }
    
    [DbcField(4)]
    public int DispelType { get; set; }
    
    [DbcField(5)]
    public int Mechanic { get; set; }
    
    [DbcField(6)]
    public int Attributes { get; set; }
    
    [DbcField(7)]
    public int AttributesEx { get; set; }
    
    [DbcField(8)]
    public int AttributesEx2 { get; set; }
    
    [DbcField(9)]
    public int AttributesEx3 { get; set; }
    
    [DbcField(10)]
    public int AttributesEx4 { get; set; }
    
    [DbcField(11)]
    public int ShapeshiftMask { get; set; }
    
    [DbcField(12)]
    public int ShapeshiftExclude { get; set; }
    
    [DbcField(13)]
    public int Targets { get; set; }
    
    [DbcField(14)]
    public int TargetCreatureType { get; set; }
    
    [DbcField(15)]
    public int RequiresSpellFocus { get; set; }
    
    [DbcField(16)]
    public int CasterAuraState { get; set; }
    
    [DbcField(17)]
    public int TargetAuraState { get; set; }
    
    [DbcField(18)]
    public int CastingTimeIndex { get; set; }
    
    [DbcField(19)]
    public int RecoveryTime { get; set; }
    
    [DbcField(20)]
    public int CategoryRecoveryTime { get; set; }
    
    [DbcField(21)]
    public int InterruptFlags { get; set; }
    
    [DbcField(22)]
    public int AuraInterruptFlags { get; set; }
    
    [DbcField(23)]
    public int ChannelInterruptFlags { get; set; }
    
    [DbcField(24)]
    public int ProcTypeMask { get; set; }
    
    [DbcField(25)]
    public int ProcChance { get; set; }
    
    [DbcField(26)]
    public int ProcCharges { get; set; }
    
    [DbcField(27)]
    public int MaxLevel { get; set; }
    
    [DbcField(28)]
    public int BaseLevel { get; set; }
    
    [DbcField(29)]
    public int SpellLevel { get; set; }
    
    [DbcField(30)]
    public int DurationIndex { get; set; }
    
    [DbcField(31)]
    public int PowerType { get; set; }
    
    [DbcField(32)]
    public int ManaCost { get; set; }
    
    [DbcField(33)]
    public int ManaCostPerLevel { get; set; }
    
    [DbcField(34)]
    public int ManaCostPerSecond { get; set; }
    
    [DbcField(35)]
    public int ManaCostPerSecondPerLevel { get; set; }
    
    [DbcField(36)]
    public int RangeIndex { get; set; }
    
    [DbcField(37)]
    public float Speed { get; set; }
    
    [DbcField(38)]
    public int ModalNextSpell { get; set; }
    
    [DbcField(39)]
    public int StackAmount { get; set; }
    
    [DbcField(40)]
    public int Totem { get; set; }
    
    [DbcField(41)]
    public int Totem2 { get; set; }
    
    [DbcField(42, 8)]
    public int[] Reagents { get; set; }
    
    [DbcField(50, 8)]
    public int[] ReagentCounts { get; set; }
    
    [DbcField(58)]
    public int EquippedItemClass { get; set; }
    
    [DbcField(59)]
    public int EquippedItemSubclass { get; set; }
    
    [DbcField(60)]
    public int EquippedItemInvType { get; set; }
    
    [DbcField(61, 3)]
    public int[] Effects { get; set; }
    
    [DbcField(64, 3)]
    public int[] EffectDieSides { get; set; }
    
    [DbcField(67, 3)]
    public int[] EffectBaseDice { get; set; }
    
    [DbcField(70, 3)]
    public float[] EffectDicePerLevel { get; set; }
    
    [DbcField(73, 3)]
    public float[] EffectRealPointsPerLevel { get; set; }
    
    [DbcField(76, 3)]
    public int[] EffectBasePoints { get; set; }
    
    [DbcField(79, 3)]
    public int[] EffectMechanic { get; set; }
    
    [DbcField(82, 3)]
    public int[] ImplicitTargetA { get; set; }
    
    [DbcField(85, 3)]
    public int[] ImplicitTargetB { get; set; }
    
    [DbcField(88, 3)]
    public int[] EffectRadiusIndex { get; set; }
    
    [DbcField(91, 3)]
    public int[] EffectAura { get; set; }
    
    [DbcField(94, 3)]
    public float[] EffectAmplitude { get; set; }
    
    [DbcField(97, 3)]
    public float[] EffectMultipleValue { get; set; }
    
    [DbcField(100, 3)]
    public int[] EffectChainTarget { get; set; }
    
    [DbcField(103, 3)]
    public int[] EffectItemType { get; set; }
    
    [DbcField(106, 3)]
    public int[] EffectMiscValue { get; set; }
    
    [DbcField(109, 3)]
    public int[] EffectTriggerSpell { get; set; }
    
    [DbcField(112, 3)]
    public float[] EffectPointsPerCombo { get; set; }
    
    [DbcField(115, 2)]
    public int[] SpellVisuals { get; set; }
    
    [DbcField(117)]
    public int SpellIcon { get; set; }
    
    [DbcField(118)]
    public int ActiveIcon { get; set; }
    
    [DbcField(119, clientOnly: true)]
    public int SpellPriority { get; set; }
    
    [DbcField(120, 8)]
    public string[] Names { get; set; }

    [DbcField(128)]
    public int Unknown128 { get; set; }

    [DbcField(129, 8)]
    public string[] Ranks { get; set; }
    
    [DbcField(137)]
    public int Unknown137 { get; set; }

    [DbcField(138, 8)]
    public string[] Descriptions { get; set; }
    
    [DbcField(146)]
    public int Unknown146 { get; set; }

    [DbcField(147, 8)]
    public string[] Tooltips { get; set; }
    
    [DbcField(155)]
    public int Unknown155 { get; set; }
    
    [DbcField(156)]
    public int ManaCostPct { get; set; }
    
    [DbcField(157)]
    public int StartRecoveryCategory { get; set; }
    
    [DbcField(158)]
    public int StartRecoveryTime { get; set; }
    
    [DbcField(159)]
    public int MaxTargetLevel { get; set; }
    
    [DbcField(160)]
    public int SpellClassSet { get; set; }
    
    [DbcField(161)]
    public int SpellClassMask0 { get; set; }
    
    [DbcField(162)]
    public int SpellClassMask1 { get; set; }
    
    [DbcField(163)]
    public int MaxTargets { get; set; }
    
    [DbcField(164)]
    public int DefenseType { get; set; }
    
    [DbcField(165)]
    public int PreventionType { get; set; }
    
    [DbcField(166)]
    public int StanceBarOrder { get; set; }
    
    [DbcField(167, 3)]
    public float[] DamageMultipliers { get; set; }
    
    [DbcField(170)]
    public int MinFaction { get; set; }
    
    [DbcField(171)]
    public int MinReputation { get; set; }
    
    [DbcField(172)]
    public int RequiredAuraVision { get; set; }
}