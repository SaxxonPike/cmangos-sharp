using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.CharacterDatabase;

[Table("world")]
public class World
{
    [Column("data", TypeName="longtext")]
    public virtual string Data { get; set; }

    [Column("map", TypeName="int")]
    public virtual uint Map { get; set; }

}