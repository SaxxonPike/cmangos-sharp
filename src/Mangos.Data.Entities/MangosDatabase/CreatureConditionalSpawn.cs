using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("creature_conditional_spawn")]
public class CreatureConditionalSpawn
{
    [Column("Comments")]
    [MaxLength(255)]
    public virtual string Comments { get; set; }

    /* Alliance Creature Identifier */
    [Column("EntryAlliance", TypeName="mediumint")]
    public virtual uint EntryAlliance { get; set; }

    /* Horde Creature Identifier */
    [Column("EntryHorde", TypeName="mediumint")]
    public virtual uint EntryHorde { get; set; }

    /* Global Unique Identifier */
    [Column("Guid", TypeName="int")]
    public virtual uint Guid { get; set; }

}