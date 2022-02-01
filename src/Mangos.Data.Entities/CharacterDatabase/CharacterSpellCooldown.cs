using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.CharacterDatabase;

[Table("character_spell_cooldown")]
public class CharacterSpellCooldown
{
    /* Spell category */
    [Column("Category", TypeName="int")]
    public virtual uint Category { get; set; }

    /* Spell category cooldown expire time */
    [Column("CategoryExpireTime", TypeName="bigint")]
    public virtual ulong CategoryExpireTime { get; set; }

    /* Global Unique Identifier, Low part */
    [Column("guid", TypeName="int")]
    public virtual uint Guid { get; set; }

    /* Item Identifier */
    [Column("ItemId", TypeName="int")]
    public virtual uint ItemId { get; set; }

    /* Spell cooldown expire time */
    [Column("SpellExpireTime", TypeName="bigint")]
    public virtual ulong SpellExpireTime { get; set; }

    /* Spell Identifier */
    [Column("SpellId", TypeName="int")]
    public virtual uint SpellId { get; set; }

}