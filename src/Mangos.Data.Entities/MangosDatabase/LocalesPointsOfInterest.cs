using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("locales_points_of_interest")]
public class LocalesPointsOfInterest
{
    [Column("entry", TypeName="mediumint")]
    public virtual uint Entry { get; set; }

    [Column("icon_name_loc1", TypeName="text")]
    [MaxLength(65535)]
    public virtual string IconNameLoc1 { get; set; }

    [Column("icon_name_loc2", TypeName="text")]
    [MaxLength(65535)]
    public virtual string IconNameLoc2 { get; set; }

    [Column("icon_name_loc3", TypeName="text")]
    [MaxLength(65535)]
    public virtual string IconNameLoc3 { get; set; }

    [Column("icon_name_loc4", TypeName="text")]
    [MaxLength(65535)]
    public virtual string IconNameLoc4 { get; set; }

    [Column("icon_name_loc5", TypeName="text")]
    [MaxLength(65535)]
    public virtual string IconNameLoc5 { get; set; }

    [Column("icon_name_loc6", TypeName="text")]
    [MaxLength(65535)]
    public virtual string IconNameLoc6 { get; set; }

    [Column("icon_name_loc7", TypeName="text")]
    [MaxLength(65535)]
    public virtual string IconNameLoc7 { get; set; }

    [Column("icon_name_loc8", TypeName="text")]
    [MaxLength(65535)]
    public virtual string IconNameLoc8 { get; set; }

}