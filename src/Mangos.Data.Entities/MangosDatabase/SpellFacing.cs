using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("spell_facing")]
public class SpellFacing
{
    /* Spell ID */
    [Column("entry", TypeName="int")]
    public virtual uint Entry { get; set; }

    /* flag for facing state, usually 1 */
    [Column("facingcasterflag", TypeName="tinyint")]
    public virtual int Facingcasterflag { get; set; }

}