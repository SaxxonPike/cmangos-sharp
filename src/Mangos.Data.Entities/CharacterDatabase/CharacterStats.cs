using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.CharacterDatabase;

[Table("character_stats")]
public class CharacterStats
{
    [Column("agility", TypeName="int")]
    public virtual uint Agility { get; set; }

    [Column("armor", TypeName="int")]
    public virtual uint Armor { get; set; }

    [Column("attackPower", TypeName="int")]
    public virtual uint AttackPower { get; set; }

    [Column("blockPct", TypeName="float")]
    public virtual float BlockPct { get; set; }

    [Column("critPct", TypeName="float")]
    public virtual float CritPct { get; set; }

    [Column("dodgePct", TypeName="float")]
    public virtual float DodgePct { get; set; }

    /* Global Unique Identifier, Low part */
    [Column("guid", TypeName="int")]
    public virtual uint Guid { get; set; }

    [Column("intellect", TypeName="int")]
    public virtual uint Intellect { get; set; }

    [Column("maxhealth", TypeName="int")]
    public virtual uint Maxhealth { get; set; }

    [Column("maxpower1", TypeName="int")]
    public virtual uint Maxpower1 { get; set; }

    [Column("maxpower2", TypeName="int")]
    public virtual uint Maxpower2 { get; set; }

    [Column("maxpower3", TypeName="int")]
    public virtual uint Maxpower3 { get; set; }

    [Column("maxpower4", TypeName="int")]
    public virtual uint Maxpower4 { get; set; }

    [Column("maxpower5", TypeName="int")]
    public virtual uint Maxpower5 { get; set; }

    [Column("maxpower6", TypeName="int")]
    public virtual uint Maxpower6 { get; set; }

    [Column("maxpower7", TypeName="int")]
    public virtual uint Maxpower7 { get; set; }

    [Column("parryPct", TypeName="float")]
    public virtual float ParryPct { get; set; }

    [Column("rangedAttackPower", TypeName="int")]
    public virtual uint RangedAttackPower { get; set; }

    [Column("rangedCritPct", TypeName="float")]
    public virtual float RangedCritPct { get; set; }

    [Column("resArcane", TypeName="int")]
    public virtual uint ResArcane { get; set; }

    [Column("resFire", TypeName="int")]
    public virtual uint ResFire { get; set; }

    [Column("resFrost", TypeName="int")]
    public virtual uint ResFrost { get; set; }

    [Column("resHoly", TypeName="int")]
    public virtual uint ResHoly { get; set; }

    [Column("resNature", TypeName="int")]
    public virtual uint ResNature { get; set; }

    [Column("resShadow", TypeName="int")]
    public virtual uint ResShadow { get; set; }

    [Column("spirit", TypeName="int")]
    public virtual uint Spirit { get; set; }

    [Column("stamina", TypeName="int")]
    public virtual uint Stamina { get; set; }

    [Column("strength", TypeName="int")]
    public virtual uint Strength { get; set; }

}