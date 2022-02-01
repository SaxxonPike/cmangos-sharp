using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.CharacterDatabase;

[Table("character_spell")]
public class CharacterSpell
{
    [Column("active", TypeName="tinyint")]
    public virtual byte Active { get; set; }

    [Column("disabled", TypeName="tinyint")]
    public virtual byte Disabled { get; set; }

    /* Global Unique Identifier */
    [Column("guid", TypeName="int")]
    public virtual uint Guid { get; set; }

    /* Spell Identifier */
    [Column("spell", TypeName="int")]
    public virtual uint Spell { get; set; }

}