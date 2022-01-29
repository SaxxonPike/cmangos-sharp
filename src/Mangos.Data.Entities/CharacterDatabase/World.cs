using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.CharacterDatabase;

[Table("world")]
public class World
{
    [Column("map", TypeName="int")]
    public virtual uint Map { get; set; }

    [Column("data", TypeName="longtext")]
    public virtual string Data { get; set; }

}