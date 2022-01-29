using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.CharacterDatabase;

[Table("world_state")]
public class WorldState
{
    /* Internal save ID */
    [Column("Id", TypeName="int")]
    public virtual uint Id { get; set; }

    [Column("Data", TypeName="longtext")]
    public virtual string Data { get; set; }

}