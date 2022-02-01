using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("game_event_creature")]
public class GameEventCreature
{
    /* Negatives value to remove during event and ignore pool grouping, positive value for spawn during event and if guid is part of pool then al pool memebers must be listed as part of event spawn. */
    [Column("Event", TypeName="smallint")]
    public virtual short Event { get; set; }

    [Column("guid", TypeName="int")]
    public virtual uint Guid { get; set; }

}