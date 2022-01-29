using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("spawn_group_linked_group")]
public class SpawnGroupLinkedGroup
{
    /* Spawn Group ID */
    [Column("Id", TypeName="int")]
    public virtual int Id { get; set; }

    /* Linked Spawn Group ID */
    [Column("LinkedId", TypeName="int")]
    public virtual int LinkedId { get; set; }

}