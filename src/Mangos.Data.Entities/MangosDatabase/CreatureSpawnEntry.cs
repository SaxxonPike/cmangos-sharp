using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("creature_spawn_entry")]
public class CreatureSpawnEntry
{
    /* Global Unique Identifier */
    [Column("guid", TypeName="int")]
    public virtual uint Guid { get; set; }

    [Column("entry", TypeName="mediumint")]
    public virtual uint Entry { get; set; }

}