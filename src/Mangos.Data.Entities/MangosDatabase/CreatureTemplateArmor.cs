using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("creature_template_armor")]
public class CreatureTemplateArmor
{
    [Column("Entry", TypeName="mediumint")]
    public virtual uint Entry { get; set; }

    [Column("Name", TypeName="char")]
    [MaxLength(100)]
    public virtual string Name { get; set; }

    [Column("SubName", TypeName="char")]
    [MaxLength(100)]
    public virtual string SubName { get; set; }

    [Column("MinLevel", TypeName="tinyint")]
    public virtual byte MinLevel { get; set; }

    [Column("MaxLevel", TypeName="tinyint")]
    public virtual byte MaxLevel { get; set; }

    [Column("ModelId1", TypeName="mediumint")]
    public virtual uint ModelId1 { get; set; }

    [Column("ModelId2", TypeName="mediumint")]
    public virtual uint ModelId2 { get; set; }

    [Column("ModelId3", TypeName="mediumint")]
    public virtual uint ModelId3 { get; set; }

    [Column("ModelId4", TypeName="mediumint")]
    public virtual uint ModelId4 { get; set; }

    [Column("FactionAlliance", TypeName="smallint")]
    public virtual uint FactionAlliance { get; set; }

    [Column("FactionHorde", TypeName="smallint")]
    public virtual uint FactionHorde { get; set; }

    [Column("Scale", TypeName="float")]
    public virtual float Scale { get; set; }

    [Column("Family", TypeName="tinyint")]
    public virtual int Family { get; set; }

    [Column("CreatureType", TypeName="tinyint")]
    public virtual byte CreatureType { get; set; }

    [Column("InhabitType", TypeName="tinyint")]
    public virtual byte InhabitType { get; set; }

    [Column("RegenerateStats", TypeName="tinyint")]
    public virtual byte RegenerateStats { get; set; }

    [Column("RacialLeader", TypeName="tinyint")]
    public virtual byte RacialLeader { get; set; }

    [Column("NpcFlags", TypeName="int")]
    public virtual uint NpcFlags { get; set; }

    [Column("UnitFlags", TypeName="int")]
    public virtual uint UnitFlags { get; set; }

    [Column("DynamicFlags", TypeName="int")]
    public virtual uint DynamicFlags { get; set; }

    [Column("ExtraFlags", TypeName="int")]
    public virtual uint ExtraFlags { get; set; }

    [Column("CreatureTypeFlags", TypeName="int")]
    public virtual uint CreatureTypeFlags { get; set; }

    [Column("SpeedWalk", TypeName="float")]
    public virtual float SpeedWalk { get; set; }

    [Column("SpeedRun", TypeName="float")]
    public virtual float SpeedRun { get; set; }

    [Column("UnitClass", TypeName="tinyint")]
    public virtual byte UnitClass { get; set; }

    [Column("Rank", TypeName="tinyint")]
    public virtual byte Rank { get; set; }

    [Column("HealthMultiplier", TypeName="float")]
    public virtual float HealthMultiplier { get; set; }

    [Column("PowerMultiplier", TypeName="float")]
    public virtual float PowerMultiplier { get; set; }

    [Column("DamageMultiplier", TypeName="float")]
    public virtual float DamageMultiplier { get; set; }

    [Column("DamageVariance", TypeName="float")]
    public virtual float DamageVariance { get; set; }

    [Column("ArmorMultiplier", TypeName="float")]
    public virtual float ArmorMultiplier { get; set; }

    [Column("ExperienceMultiplier", TypeName="float")]
    public virtual float ExperienceMultiplier { get; set; }

    [Column("MinLevelHealth", TypeName="int")]
    public virtual uint MinLevelHealth { get; set; }

    [Column("MaxLevelHealth", TypeName="int")]
    public virtual uint MaxLevelHealth { get; set; }

    [Column("MinLevelMana", TypeName="int")]
    public virtual uint MinLevelMana { get; set; }

    [Column("MaxLevelMana", TypeName="int")]
    public virtual uint MaxLevelMana { get; set; }

    [Column("MinMeleeDmg", TypeName="float")]
    public virtual float MinMeleeDmg { get; set; }

    [Column("MaxMeleeDmg", TypeName="float")]
    public virtual float MaxMeleeDmg { get; set; }

    [Column("MinRangedDmg", TypeName="float")]
    public virtual float MinRangedDmg { get; set; }

    [Column("MaxRangedDmg", TypeName="float")]
    public virtual float MaxRangedDmg { get; set; }

    [Column("Armor", TypeName="mediumint")]
    public virtual uint Armor { get; set; }

    [Column("MeleeAttackPower", TypeName="int")]
    public virtual uint MeleeAttackPower { get; set; }

    [Column("RangedAttackPower", TypeName="smallint")]
    public virtual uint RangedAttackPower { get; set; }

    [Column("MeleeBaseAttackTime", TypeName="int")]
    public virtual uint MeleeBaseAttackTime { get; set; }

    [Column("RangedBaseAttackTime", TypeName="int")]
    public virtual uint RangedBaseAttackTime { get; set; }

    [Column("DamageSchool", TypeName="tinyint")]
    public virtual int DamageSchool { get; set; }

    [Column("MinLootGold", TypeName="mediumint")]
    public virtual uint MinLootGold { get; set; }

    [Column("MaxLootGold", TypeName="mediumint")]
    public virtual uint MaxLootGold { get; set; }

    [Column("LootId", TypeName="mediumint")]
    public virtual uint LootId { get; set; }

    [Column("PickpocketLootId", TypeName="mediumint")]
    public virtual uint PickpocketLootId { get; set; }

    [Column("SkinningLootId", TypeName="mediumint")]
    public virtual uint SkinningLootId { get; set; }

    [Column("KillCredit1", TypeName="int")]
    public virtual uint KillCredit1 { get; set; }

    [Column("KillCredit2", TypeName="int")]
    public virtual uint KillCredit2 { get; set; }

    [Column("MechanicImmuneMask", TypeName="int")]
    public virtual uint MechanicImmuneMask { get; set; }

    [Column("SchoolImmuneMask", TypeName="int")]
    public virtual uint SchoolImmuneMask { get; set; }

    [Column("ResistanceHoly", TypeName="smallint")]
    public virtual int ResistanceHoly { get; set; }

    [Column("ResistanceFire", TypeName="smallint")]
    public virtual int ResistanceFire { get; set; }

    [Column("ResistanceNature", TypeName="smallint")]
    public virtual int ResistanceNature { get; set; }

    [Column("ResistanceFrost", TypeName="smallint")]
    public virtual int ResistanceFrost { get; set; }

    [Column("ResistanceShadow", TypeName="smallint")]
    public virtual int ResistanceShadow { get; set; }

    [Column("ResistanceArcane", TypeName="smallint")]
    public virtual int ResistanceArcane { get; set; }

    [Column("PetSpellDataId", TypeName="mediumint")]
    public virtual uint PetSpellDataId { get; set; }

    [Column("MovementType", TypeName="tinyint")]
    public virtual byte MovementType { get; set; }

    [Column("TrainerType", TypeName="tinyint")]
    public virtual int TrainerType { get; set; }

    [Column("TrainerSpell", TypeName="mediumint")]
    public virtual uint TrainerSpell { get; set; }

    [Column("TrainerClass", TypeName="tinyint")]
    public virtual byte TrainerClass { get; set; }

    [Column("TrainerRace", TypeName="tinyint")]
    public virtual byte TrainerRace { get; set; }

    [Column("TrainerTemplateId", TypeName="mediumint")]
    public virtual uint TrainerTemplateId { get; set; }

    [Column("VendorTemplateId", TypeName="mediumint")]
    public virtual uint VendorTemplateId { get; set; }

    [Column("GossipMenuId", TypeName="mediumint")]
    public virtual uint GossipMenuId { get; set; }

    [Column("EquipmentTemplateId", TypeName="mediumint")]
    public virtual uint EquipmentTemplateId { get; set; }

    [Column("Civilian", TypeName="tinyint")]
    public virtual byte Civilian { get; set; }

    [Column("AIName", TypeName="char")]
    [MaxLength(64)]
    public virtual string AiName { get; set; }

    [Column("ScriptName", TypeName="char")]
    [MaxLength(64)]
    public virtual string ScriptName { get; set; }

}