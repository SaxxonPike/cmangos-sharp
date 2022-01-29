using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.CharacterDatabase;

[Table("character_reputation")]
public class CharacterReputation
{
    /* Global Unique Identifier */
    [Column("guid", TypeName="int")]
    public virtual uint Guid { get; set; }

    [Column("faction", TypeName="int")]
    public virtual uint Faction { get; set; }

    [Column("standing", TypeName="int")]
    public virtual int Standing { get; set; }

    [Column("flags", TypeName="int")]
    public virtual int Flags { get; set; }

}