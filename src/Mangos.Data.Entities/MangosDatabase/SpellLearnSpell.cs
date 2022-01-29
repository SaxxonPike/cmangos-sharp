using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("spell_learn_spell")]
public class SpellLearnSpell
{
    [Column("entry", TypeName="smallint")]
    public virtual uint Entry { get; set; }

    [Column("SpellID", TypeName="smallint")]
    public virtual uint SpellId { get; set; }

    [Column("Active", TypeName="tinyint")]
    public virtual byte Active { get; set; }

}