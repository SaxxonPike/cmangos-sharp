using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("creature_spawn_data")]
public class CreatureSpawnData
{
    /* guid of creature */
    [Column("Guid", TypeName="int")]
    public virtual uint Guid { get; set; }

    /* ID of template */
    [Column("Id", TypeName="int")]
    public virtual uint Id { get; set; }

}