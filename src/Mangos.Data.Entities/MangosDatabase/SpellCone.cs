using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("spell_cone")]
public class SpellCone
{
    [Column("Id", TypeName="int")]
    public virtual uint Id { get; set; }

    [Column("ConeDegrees", TypeName="int")]
    public virtual int ConeDegrees { get; set; }

}