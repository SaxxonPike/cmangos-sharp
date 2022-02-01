using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.CharacterDatabase;

[Table("character_action")]
public class CharacterAction
{
    [Column("action", TypeName="int")]
    public virtual uint Action { get; set; }

    [Column("button", TypeName="tinyint")]
    public virtual byte Button { get; set; }

    /* Global Unique Identifier */
    [Column("guid", TypeName="int")]
    public virtual uint Guid { get; set; }

    [Column("type", TypeName="tinyint")]
    public virtual byte Type { get; set; }

}