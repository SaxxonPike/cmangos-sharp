using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("creature_template")]
public class CreatureTemplate
{
    [Column("AIName", TypeName="char")]
    [MaxLength(64)]
    public virtual string AIName { get; set; }

    [Column("Armor", TypeName="mediumint")]
    public virtual uint Armor { get; set; }

    [Column("ArmorMultiplier", TypeName="float")]
    public virtual float ArmorMultiplier { get; set; }

    /* Range in which creature calls for help? */
    [Column("CallForHelp", TypeName="int")]
    public virtual uint CallForHelp { get; set; }

    [Column("Civilian", TypeName="tinyint")]
    public virtual byte Civilian { get; set; }

    /* Time before corpse despawns */
    [Column("CorpseDecay", TypeName="int")]
    public virtual uint CorpseDecay { get; set; }

    [Column("CreatureType", TypeName="tinyint")]
    public virtual byte CreatureType { get; set; }

    [Column("CreatureTypeFlags", TypeName="int")]
    public virtual uint CreatureTypeFlags { get; set; }

    [Column("DamageMultiplier", TypeName="float")]
    public virtual float DamageMultiplier { get; set; }

    [Column("DamageSchool", TypeName="tinyint")]
    public virtual sbyte DamageSchool { get; set; }

    [Column("DamageVariance", TypeName="float")]
    public virtual float DamageVariance { get; set; }

    /* Detection range for proximity */
    [Column("Detection", TypeName="int")]
    public virtual uint Detection { get; set; }

    [Column("DynamicFlags", TypeName="int")]
    public virtual uint DynamicFlags { get; set; }

    [Column("Entry", TypeName="mediumint")]
    public virtual uint Entry { get; set; }

    [Column("EquipmentTemplateId", TypeName="mediumint")]
    public virtual uint EquipmentTemplateId { get; set; }

    [Column("ExperienceMultiplier", TypeName="float")]
    public virtual float ExperienceMultiplier { get; set; }

    [Column("ExtraFlags", TypeName="int")]
    public virtual uint ExtraFlags { get; set; }

    [Column("Faction", TypeName="smallint")]
    public virtual ushort Faction { get; set; }

    [Column("Family", TypeName="tinyint")]
    public virtual sbyte Family { get; set; }

    [Column("GossipMenuId", TypeName="mediumint")]
    public virtual uint GossipMenuId { get; set; }

    [Column("HealthMultiplier", TypeName="float")]
    public virtual float HealthMultiplier { get; set; }

    [Column("InhabitType", TypeName="tinyint")]
    public virtual byte InhabitType { get; set; }

    [Column("KillCredit1", TypeName="int")]
    public virtual uint KillCredit1 { get; set; }

    [Column("KillCredit2", TypeName="int")]
    public virtual uint KillCredit2 { get; set; }

    /* Leash range from combat start position */
    [Column("Leash", TypeName="int")]
    public virtual uint Leash { get; set; }

    [Column("LootId", TypeName="mediumint")]
    public virtual uint LootId { get; set; }

    [Column("MaxLevel", TypeName="tinyint")]
    public virtual byte MaxLevel { get; set; }

    [Column("MaxLevelHealth", TypeName="int")]
    public virtual uint MaxLevelHealth { get; set; }

    [Column("MaxLevelMana", TypeName="int")]
    public virtual uint MaxLevelMana { get; set; }

    [Column("MaxLootGold", TypeName="mediumint")]
    public virtual uint MaxLootGold { get; set; }

    [Column("MaxMeleeDmg", TypeName="float")]
    public virtual float MaxMeleeDmg { get; set; }

    [Column("MaxRangedDmg", TypeName="float")]
    public virtual float MaxRangedDmg { get; set; }

    [Column("MechanicImmuneMask", TypeName="int")]
    public virtual uint MechanicImmuneMask { get; set; }

    [Column("MeleeAttackPower", TypeName="int")]
    public virtual uint MeleeAttackPower { get; set; }

    [Column("MeleeBaseAttackTime", TypeName="int")]
    public virtual uint MeleeBaseAttackTime { get; set; }

    [Column("MinLevel", TypeName="tinyint")]
    public virtual byte MinLevel { get; set; }

    [Column("MinLevelHealth", TypeName="int")]
    public virtual uint MinLevelHealth { get; set; }

    [Column("MinLevelMana", TypeName="int")]
    public virtual uint MinLevelMana { get; set; }

    [Column("MinLootGold", TypeName="mediumint")]
    public virtual uint MinLootGold { get; set; }

    [Column("MinMeleeDmg", TypeName="float")]
    public virtual float MinMeleeDmg { get; set; }

    [Column("MinRangedDmg", TypeName="float")]
    public virtual float MinRangedDmg { get; set; }

    [Column("ModelId1", TypeName="mediumint")]
    public virtual uint ModelId1 { get; set; }

    [Column("ModelId2", TypeName="mediumint")]
    public virtual uint ModelId2 { get; set; }

    [Column("ModelId3", TypeName="mediumint")]
    public virtual uint ModelId3 { get; set; }

    [Column("ModelId4", TypeName="mediumint")]
    public virtual uint ModelId4 { get; set; }

    [Column("MovementType", TypeName="tinyint")]
    public virtual byte MovementType { get; set; }

    [Column("Name", TypeName="char")]
    [MaxLength(100)]
    public virtual string Name { get; set; }

    [Column("NpcFlags", TypeName="int")]
    public virtual uint NpcFlags { get; set; }

    [Column("PetSpellDataId", TypeName="mediumint")]
    public virtual uint PetSpellDataId { get; set; }

    [Column("PickpocketLootId", TypeName="mediumint")]
    public virtual uint PickpocketLootId { get; set; }

    [Column("PowerMultiplier", TypeName="float")]
    public virtual float PowerMultiplier { get; set; }

    /* When exceeded during pursuit creature evades? */
    [Column("Pursuit", TypeName="int")]
    public virtual uint Pursuit { get; set; }

    [Column("RacialLeader", TypeName="tinyint")]
    public virtual byte RacialLeader { get; set; }

    [Column("RangedAttackPower", TypeName="smallint")]
    public virtual ushort RangedAttackPower { get; set; }

    [Column("RangedBaseAttackTime", TypeName="int")]
    public virtual uint RangedBaseAttackTime { get; set; }

    [Column("Rank", TypeName="tinyint")]
    public virtual byte Rank { get; set; }

    [Column("RegenerateStats", TypeName="tinyint")]
    public virtual byte RegenerateStats { get; set; }

    [Column("ResistanceArcane", TypeName="smallint")]
    public virtual short ResistanceArcane { get; set; }

    [Column("ResistanceFire", TypeName="smallint")]
    public virtual short ResistanceFire { get; set; }

    [Column("ResistanceFrost", TypeName="smallint")]
    public virtual short ResistanceFrost { get; set; }

    [Column("ResistanceHoly", TypeName="smallint")]
    public virtual short ResistanceHoly { get; set; }

    [Column("ResistanceNature", TypeName="smallint")]
    public virtual short ResistanceNature { get; set; }

    [Column("ResistanceShadow", TypeName="smallint")]
    public virtual short ResistanceShadow { get; set; }

    [Column("Scale", TypeName="float")]
    public virtual float Scale { get; set; }

    [Column("SchoolImmuneMask", TypeName="int")]
    public virtual uint SchoolImmuneMask { get; set; }

    [Column("ScriptName", TypeName="char")]
    [MaxLength(64)]
    public virtual string ScriptName { get; set; }

    [Column("SkinningLootId", TypeName="mediumint")]
    public virtual uint SkinningLootId { get; set; }

    [Column("SpeedRun", TypeName="float")]
    public virtual float SpeedRun { get; set; }

    [Column("SpeedWalk", TypeName="float")]
    public virtual float SpeedWalk { get; set; }

    /* creature_spell_list_entry */
    [Column("SpellList", TypeName="int")]
    public virtual int SpellList { get; set; }

    [Column("SubName", TypeName="char")]
    [MaxLength(100)]
    public virtual string SubName { get; set; }

    /* Time for refreshing leashing before evade? */
    [Column("Timeout", TypeName="int")]
    public virtual uint Timeout { get; set; }

    [Column("TrainerClass", TypeName="tinyint")]
    public virtual byte TrainerClass { get; set; }

    [Column("TrainerRace", TypeName="tinyint")]
    public virtual byte TrainerRace { get; set; }

    [Column("TrainerSpell", TypeName="mediumint")]
    public virtual uint TrainerSpell { get; set; }

    [Column("TrainerTemplateId", TypeName="mediumint")]
    public virtual uint TrainerTemplateId { get; set; }

    [Column("TrainerType", TypeName="tinyint")]
    public virtual sbyte TrainerType { get; set; }

    [Column("UnitClass", TypeName="tinyint")]
    public virtual byte UnitClass { get; set; }

    [Column("UnitFlags", TypeName="int")]
    public virtual uint UnitFlags { get; set; }

    [Column("VendorTemplateId", TypeName="mediumint")]
    public virtual uint VendorTemplateId { get; set; }

    [Column("visibilityDistanceType", TypeName="tinyint")]
    public virtual sbyte VisibilityDistanceType { get; set; }

}