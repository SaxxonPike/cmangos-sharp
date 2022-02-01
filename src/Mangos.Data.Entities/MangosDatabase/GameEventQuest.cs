using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("game_event_quest")]
public class GameEventQuest
{
    /* entry from game_event */
    [Column("Event", TypeName="smallint")]
    public virtual ushort Event { get; set; }

    /* entry from quest_template */
    [Column("quest", TypeName="mediumint")]
    public virtual uint Quest { get; set; }

}