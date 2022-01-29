using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("spawn_group_entry")]
public class SpawnGroupEntry
{
    /* Spawn Group ID */
    [Column("Id", TypeName="int")]
    public virtual int Id { get; set; }

    /* Entry of creature or GO */
    [Column("Entry", TypeName="int")]
    public virtual int Entry { get; set; }

    /* Minimum count of entry in a group before random */
    [Column("MinCount", TypeName="int")]
    public virtual int MinCount { get; set; }

    /* Maximum total count of entry in a group */
    [Column("MaxCount", TypeName="int")]
    public virtual int MaxCount { get; set; }

    /* Chance for entry to be selected */
    [Column("Chance", TypeName="int")]
    public virtual int Chance { get; set; }

}