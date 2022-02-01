using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("locales_item")]
public class LocalesItem
{
    [Column("description_loc1")]
    [MaxLength(255)]
    public virtual string DescriptionLoc1 { get; set; }

    [Column("description_loc2")]
    [MaxLength(255)]
    public virtual string DescriptionLoc2 { get; set; }

    [Column("description_loc3")]
    [MaxLength(255)]
    public virtual string DescriptionLoc3 { get; set; }

    [Column("description_loc4")]
    [MaxLength(255)]
    public virtual string DescriptionLoc4 { get; set; }

    [Column("description_loc5")]
    [MaxLength(255)]
    public virtual string DescriptionLoc5 { get; set; }

    [Column("description_loc6")]
    [MaxLength(255)]
    public virtual string DescriptionLoc6 { get; set; }

    [Column("description_loc7")]
    [MaxLength(255)]
    public virtual string DescriptionLoc7 { get; set; }

    [Column("description_loc8")]
    [MaxLength(255)]
    public virtual string DescriptionLoc8 { get; set; }

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