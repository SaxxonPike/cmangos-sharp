using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("gameobject_battleground")]
public class GameObjectBattleground
{
    /* GameObject's GUID */
    [Column("guid", TypeName="int")]
    public virtual uint Guid { get; set; }

    /* main event */
    [Column("event1", TypeName="tinyint")]
    public virtual byte Event1 { get; set; }

    /* sub event */
    [Column("event2", TypeName="tinyint")]
    public virtual byte Event2 { get; set; }

}