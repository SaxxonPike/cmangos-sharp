using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("game_tele")]
public class GameTele
{
    [Column("id", TypeName="mediumint")]
    public virtual uint Id { get; set; }

    [Column("position_x", TypeName="float")]
    public virtual float PositionX { get; set; }

    [Column("position_y", TypeName="float")]
    public virtual float PositionY { get; set; }

    [Column("position_z", TypeName="float")]
    public virtual float PositionZ { get; set; }

    [Column("orientation", TypeName="float")]
    public virtual float Orientation { get; set; }

    [Column("map", TypeName="smallint")]
    public virtual uint Map { get; set; }

    [Column("name", TypeName="varchar")]
    [MaxLength(100)]
    public virtual string Name { get; set; }

}