using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("spell_threat")]
public class SpellThreat
{
    /* additional threat bonus from attack power */
    [Column("ap_bonus", TypeName="float")]
    public virtual float ApBonus { get; set; }

    [Column("entry", TypeName="mediumint")]
    public virtual uint Entry { get; set; }

    /* threat multiplier for damage/healing */
    [Column("multiplier", TypeName="float")]
    public virtual float Multiplier { get; set; }

    [Column("Threat", TypeName="smallint")]
    public virtual short Threat { get; set; }

}