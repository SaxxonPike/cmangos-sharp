using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("world_safe_locs")]
public class WorldSafeLoc
{
    [Column("id", TypeName="int")]
    public virtual uint Id { get; set; }

    [Column("map", TypeName="int")]
    public virtual uint Map { get; set; }

    [Column("x", TypeName="float")]
    public virtual float X { get; set; }

    [Column("y", TypeName="float")]
    public virtual float Y { get; set; }

    [Column("z", TypeName="float")]
    public virtual float Z { get; set; }

    [Column("o", TypeName="float")]
    public virtual float O { get; set; }

    [Column("name")]
    [MaxLength(50)]
    public virtual string Name { get; set; }

}