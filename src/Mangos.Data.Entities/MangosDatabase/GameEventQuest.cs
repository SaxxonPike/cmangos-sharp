using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("game_event_quest")]
public class GameEventQuest
{
    /* entry from quest_template */
    [Column("quest", TypeName="mediumint")]
    public virtual uint Quest { get; set; }

    /* entry from game_event */
    [Column("event", TypeName="smallint")]
    public virtual uint Event { get; set; }

}