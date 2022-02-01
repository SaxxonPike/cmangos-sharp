using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.CharacterDatabase;

[Table("game_event_status")]
public class GameEventStatus
{
    [Column("Event", TypeName="smallint")]
    public virtual ushort Event { get; set; }

}