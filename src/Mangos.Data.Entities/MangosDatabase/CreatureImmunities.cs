using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("creature_immunities")]
public class CreatureImmunities
{
    /* creature_template entry */
    [Column("Entry", TypeName="int")]
    public virtual uint Entry { get; set; }

    /* immunity set ID */
    [Column("SetId", TypeName="int")]
    public virtual uint SetId { get; set; }

    /* enum SpellImmunity */
    [Column("Type", TypeName="tinyint")]
    public virtual byte Type { get; set; }

    /* value depending on type */
    [Column("Value", TypeName="int")]
    public virtual uint Value { get; set; }

}