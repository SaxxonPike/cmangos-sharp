using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.CharacterDatabase;

[Table("character_skills")]
public class CharacterSkills
{
    /* Global Unique Identifier */
    [Column("guid", TypeName="int")]
    public virtual uint Guid { get; set; }

    [Column("max", TypeName="mediumint")]
    public virtual uint Max { get; set; }

    [Column("skill", TypeName="mediumint")]
    public virtual uint Skill { get; set; }

    [Column("value", TypeName="mediumint")]
    public virtual uint Value { get; set; }

}