using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("locales_creature")]
public class LocalesCreature
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

    [Column("subname_loc1")]
    [MaxLength(100)]
    public virtual string SubnameLoc1 { get; set; }

    [Column("subname_loc2")]
    [MaxLength(100)]
    public virtual string SubnameLoc2 { get; set; }

    [Column("subname_loc3")]
    [MaxLength(100)]
    public virtual string SubnameLoc3 { get; set; }

    [Column("subname_loc4")]
    [MaxLength(100)]
    public virtual string SubnameLoc4 { get; set; }

    [Column("subname_loc5")]
    [MaxLength(100)]
    public virtual string SubnameLoc5 { get; set; }

    [Column("subname_loc6")]
    [MaxLength(100)]
    public virtual string SubnameLoc6 { get; set; }

    [Column("subname_loc7")]
    [MaxLength(100)]
    public virtual string SubnameLoc7 { get; set; }

    [Column("subname_loc8")]
    [MaxLength(100)]
    public virtual string SubnameLoc8 { get; set; }

}