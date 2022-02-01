using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("playercreateinfo")]
public class Playercreateinfo
{
    [Column("Class", TypeName="tinyint")]
    public virtual byte Class { get; set; }

    [Column("map", TypeName="smallint")]
    public virtual ushort Map { get; set; }

    [Column("orientation", TypeName="float")]
    public virtual float Orientation { get; set; }

    [Column("position_x", TypeName="float")]
    public virtual float PositionX { get; set; }

    [Column("position_y", TypeName="float")]
    public virtual float PositionY { get; set; }

    [Column("position_z", TypeName="float")]
    public virtual float PositionZ { get; set; }

    [Column("race", TypeName="tinyint")]
    public virtual byte Race { get; set; }

    [Column("zone", TypeName="mediumint")]
    public virtual uint Zone { get; set; }

}