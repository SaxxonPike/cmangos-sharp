using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("mangos_string")]
public class MangosString
{
    [Column("content_default", TypeName="text")]
    [MaxLength(65535)]
    public virtual string ContentDefault { get; set; }

    [Column("content_loc1", TypeName="text")]
    [MaxLength(65535)]
    public virtual string ContentLoc1 { get; set; }

    [Column("content_loc2", TypeName="text")]
    [MaxLength(65535)]
    public virtual string ContentLoc2 { get; set; }

    [Column("content_loc3", TypeName="text")]
    [MaxLength(65535)]
    public virtual string ContentLoc3 { get; set; }

    [Column("content_loc4", TypeName="text")]
    [MaxLength(65535)]
    public virtual string ContentLoc4 { get; set; }

    [Column("content_loc5", TypeName="text")]
    [MaxLength(65535)]
    public virtual string ContentLoc5 { get; set; }

    [Column("content_loc6", TypeName="text")]
    [MaxLength(65535)]
    public virtual string ContentLoc6 { get; set; }

    [Column("content_loc7", TypeName="text")]
    [MaxLength(65535)]
    public virtual string ContentLoc7 { get; set; }

    [Column("content_loc8", TypeName="text")]
    [MaxLength(65535)]
    public virtual string ContentLoc8 { get; set; }

    [Column("entry", TypeName="mediumint")]
    public virtual uint Entry { get; set; }

}