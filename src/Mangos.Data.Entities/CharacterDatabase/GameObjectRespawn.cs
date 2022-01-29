using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.CharacterDatabase;

[Table("gameobject_respawn")]
public class GameObjectRespawn
{
    /* Global Unique Identifier */
    [Column("guid", TypeName="int")]
    public virtual uint Guid { get; set; }

    [Column("respawntime", TypeName="bigint")]
    public virtual ulong Respawntime { get; set; }

    [Column("instance", TypeName="mediumint")]
    public virtual uint Instance { get; set; }

}