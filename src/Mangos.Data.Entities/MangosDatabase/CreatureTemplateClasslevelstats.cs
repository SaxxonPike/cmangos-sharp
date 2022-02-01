using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("creature_template_classlevelstats")]
public class CreatureTemplateClasslevelstats
{
    [Column("BaseArmor", TypeName="mediumint")]
    public virtual uint BaseArmor { get; set; }

    [Column("BaseDamageExp0", TypeName="float")]
    public virtual float BaseDamageExp0 { get; set; }

    [Column("BaseHealthExp0", TypeName="mediumint")]
    public virtual uint BaseHealthExp0 { get; set; }

    [Column("BaseMana", TypeName="mediumint")]
    public virtual uint BaseMana { get; set; }

    [Column("BaseMeleeAttackPower", TypeName="float")]
    public virtual float BaseMeleeAttackPower { get; set; }

    [Column("BaseRangedAttackPower", TypeName="float")]
    public virtual float BaseRangedAttackPower { get; set; }

    [Column("Class", TypeName="tinyint")]
    public virtual sbyte Class { get; set; }

    [Column("Level", TypeName="tinyint")]
    public virtual sbyte Level { get; set; }

}