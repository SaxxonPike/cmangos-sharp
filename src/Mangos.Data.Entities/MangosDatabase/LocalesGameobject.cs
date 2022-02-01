using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("locales_gameobject")]
public class LocalesGameobject
{
    [Column("entry", TypeName="mediumint")]
    public virtual uint Entry { get; set; }

    [Column("name_loc1")]
    [MaxLength(100)]
    public virtual string NameLoc1 { get; set; }

    [Column("name_loc2")]
    [MaxLength(100)]
    public virtual string NameLoc2 { get; set; }

    [Column("name_loc3")]
    [MaxLength(100)]
    public virtual string NameLoc3 { get; set; }

    [Column("name_loc4")]
    [MaxLength(100)]
    public virtual string NameLoc4 { get; set; }

    [Column("name_loc5")]
    [MaxLength(100)]
    public virtual string NameLoc5 { get; set; }

    [Column("name_loc6")]
    [MaxLength(100)]
    public virtual string NameLoc6 { get; set; }

    [Column("name_loc7")]
    [MaxLength(100)]
    public virtual string NameLoc7 { get; set; }

    [Column("name_loc8")]
    [MaxLength(100)]
    public virtual string NameLoc8 { get; set; }

}