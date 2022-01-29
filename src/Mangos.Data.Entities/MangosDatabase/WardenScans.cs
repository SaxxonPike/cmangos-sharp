using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("warden_scans")]
public class WardenScans
{
    [Column("id", TypeName="smallint")]
    public virtual uint Id { get; set; }

    [Column("type", TypeName="int")]
    public virtual int Type { get; set; }

    [Column("str", TypeName="text")]
    [MaxLength(65535)]
    public virtual string Str { get; set; }

    [Column("data", TypeName="text")]
    [MaxLength(65535)]
    public virtual string Data { get; set; }

    [Column("address", TypeName="int")]
    public virtual int Address { get; set; }

    [Column("length", TypeName="int")]
    public virtual int Length { get; set; }

    [Column("result", TypeName="tinytext")]
    [MaxLength(255)]
    public virtual string Result { get; set; }

    [Column("flags", TypeName="smallint")]
    public virtual uint Flags { get; set; }

    [Column("comment", TypeName="tinytext")]
    [MaxLength(255)]
    public virtual string Comment { get; set; }

}