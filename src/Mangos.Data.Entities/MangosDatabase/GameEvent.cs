using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("game_event")]
public class GameEvent
{
    /* Description of the event displayed in console */
    [Column("description")]
    [MaxLength(255)]
    public virtual string Description { get; set; }

    /* Entry of the game event */
    [Column("entry", TypeName="mediumint")]
    public virtual uint Entry { get; set; }

    /* Client side holiday id */
    [Column("holiday", TypeName="mediumint")]
    public virtual uint Holiday { get; set; }

    /* Length in minutes of the event */
    [Column("length", TypeName="bigint")]
    public virtual ulong Length { get; set; }

    /* This event starts only if defined LinkedTo event is started */
    [Column("linkedTo", TypeName="mediumint")]
    public virtual uint LinkedTo { get; set; }

    /* Delay in minutes between occurences of the event */
    [Column("occurence", TypeName="bigint")]
    public virtual ulong Occurence { get; set; }

    [Column("schedule_type", TypeName="int")]
    public virtual int ScheduleType { get; set; }

}