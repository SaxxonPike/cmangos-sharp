using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.CharacterDatabase;

[Table("pet_spell")]
public class PetSpell
{
    [Column("active", TypeName="int")]
    public virtual uint Active { get; set; }

    /* Global Unique Identifier */
    [Column("guid", TypeName="int")]
    public virtual uint Guid { get; set; }

    /* Spell Identifier */
    [Column("spell", TypeName="int")]
    public virtual uint Spell { get; set; }

}