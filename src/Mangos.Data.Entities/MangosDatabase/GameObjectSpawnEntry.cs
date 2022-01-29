using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("gameobject_spawn_entry")]
public class GameObjectSpawnEntry
{
    /* Gameobject table guid */
    [Column("guid", TypeName="int")]
    public virtual uint Guid { get; set; }

    /* Gameobject Template entry */
    [Column("entry", TypeName="mediumint")]
    public virtual uint Entry { get; set; }

}