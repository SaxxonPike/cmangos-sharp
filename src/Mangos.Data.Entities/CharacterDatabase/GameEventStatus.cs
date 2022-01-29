using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.CharacterDatabase;

[Table("game_event_status")]
public class GameEventStatus
{
    [Column("event", TypeName="smallint")]
    public virtual uint Event { get; set; }

}