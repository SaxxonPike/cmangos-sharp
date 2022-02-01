using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.CharacterDatabase;

[Table("character_queststatus_weekly")]
public class CharacterQueststatusWeekly
{
    /* Global Unique Identifier */
    [Column("guid", TypeName="int")]
    public virtual uint Guid { get; set; }

    /* Quest Identifier */
    [Column("quest", TypeName="int")]
    public virtual uint Quest { get; set; }

}