using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("battleground_events")]
public class BattlegroundEvents
{
    [Column("description")]
    [MaxLength(255)]
    public virtual string Description { get; set; }

    [Column("event1", TypeName="tinyint")]
    public virtual byte Event1 { get; set; }

    [Column("event2", TypeName="tinyint")]
    public virtual byte Event2 { get; set; }

    [Column("map", TypeName="smallint")]
    public virtual short Map { get; set; }

}