using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("spawn_group_spawn")]
public class SpawnGroupSpawn
{
    /* Spawn Group ID */
    [Column("Id", TypeName="int")]
    public virtual int Id { get; set; }

    /* Guid of creature or GO */
    [Column("Guid", TypeName="int")]
    public virtual int Guid { get; set; }

    /* 0 is the leader, -1 not part of the formation */
    [Column("SlotId", TypeName="tinyint")]
    public virtual int SlotId { get; set; }

}