using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("spawn_group")]
public class SpawnGroup
{
    /* Flags for various behaviour */
    [Column("Flags", TypeName="int")]
    public virtual uint Flags { get; set; }

    /* Spawn Group ID */
    [Column("Id", TypeName="int")]
    public virtual int Id { get; set; }

    /* Maximum total count of all spawns in a group */
    [Column("MaxCount", TypeName="int")]
    public virtual int MaxCount { get; set; }

    /* Description of usage */
    [Column("Name")]
    [MaxLength(200)]
    public virtual string Name { get; set; }

    /* Creature or GO spawn group */
    [Column("Type", TypeName="int")]
    public virtual int Type { get; set; }

    /* Worldstate which enables spawning of given group */
    [Column("WorldState", TypeName="int")]
    public virtual int WorldState { get; set; }

}