using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.CharacterDatabase;

[Table("pet_spell_cooldown")]
public class PetSpellCooldown
{
    /* Global Unique Identifier, Low part */
    [Column("guid", TypeName="int")]
    public virtual uint Guid { get; set; }

    /* Spell Identifier */
    [Column("spell", TypeName="int")]
    public virtual uint Spell { get; set; }

    [Column("time", TypeName="bigint")]
    public virtual ulong Time { get; set; }

}