using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("gameobject_questrelation")]
public class GameObjectQuestrelation
{
    [Column("id", TypeName="mediumint")]
    public virtual uint Id { get; set; }

    /* Quest Identifier */
    [Column("quest", TypeName="mediumint")]
    public virtual uint Quest { get; set; }

}