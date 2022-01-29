using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("game_event_time")]
public class GameEventTime
{
    /* Entry of the game event */
    [Column("entry", TypeName="mediumint")]
    public virtual uint Entry { get; set; }

    /* Absolute start date, the event will never start before */
    [Column("start_time", TypeName="datetime")]
    public virtual DateTime StartTime { get; set; }

    /* Absolute end date, the event will never start after */
    [Column("end_time", TypeName="datetime")]
    public virtual DateTime EndTime { get; set; }

}