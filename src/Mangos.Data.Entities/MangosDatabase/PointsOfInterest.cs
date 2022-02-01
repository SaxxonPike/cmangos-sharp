using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("points_of_interest")]
public class PointsOfInterest
{
    [Column("data", TypeName="mediumint")]
    public virtual uint Data { get; set; }

    [Column("entry", TypeName="mediumint")]
    public virtual uint Entry { get; set; }

    [Column("flags", TypeName="mediumint")]
    public virtual uint Flags { get; set; }

    [Column("icon", TypeName="mediumint")]
    public virtual uint Icon { get; set; }

    [Column("icon_name", TypeName="text")]
    [MaxLength(65535)]
    public virtual string IconName { get; set; }

    [Column("x", TypeName="float")]
    public virtual float X { get; set; }

    [Column("y", TypeName="float")]
    public virtual float Y { get; set; }

}