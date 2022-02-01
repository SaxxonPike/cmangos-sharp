using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("spell_learn_spell")]
public class SpellLearnSpell
{
    [Column("Active", TypeName="tinyint")]
    public virtual byte Active { get; set; }

    [Column("entry", TypeName="smallint")]
    public virtual ushort Entry { get; set; }

    [Column("SpellID", TypeName="smallint")]
    public virtual ushort SpellID { get; set; }

}