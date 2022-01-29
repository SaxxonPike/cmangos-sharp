using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("spell_bonus_data")]
public class SpellBonusData
{
    [Column("entry", TypeName="smallint")]
    public virtual uint Entry { get; set; }

    [Column("direct_bonus", TypeName="float")]
    public virtual float DirectBonus { get; set; }

    [Column("dot_bonus", TypeName="float")]
    public virtual float DotBonus { get; set; }

    [Column("ap_bonus", TypeName="float")]
    public virtual float ApBonus { get; set; }

    [Column("ap_dot_bonus", TypeName="float")]
    public virtual float ApDotBonus { get; set; }

    [Column("comments", TypeName="varchar")]
    [MaxLength(255)]
    public virtual string Comments { get; set; }

}