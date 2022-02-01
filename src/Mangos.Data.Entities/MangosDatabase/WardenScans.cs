using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("warden_scans")]
public class WardenScans
{
    [Column("address", TypeName="int")]
    public virtual int Address { get; set; }

    [Column("comment", TypeName="tinytext")]
    [MaxLength(255)]
    public virtual string Comment { get; set; }

    [Column("data", TypeName="text")]
    [MaxLength(65535)]
    public virtual string Data { get; set; }

    [Column("flags", TypeName="smallint")]
    public virtual ushort Flags { get; set; }

    [Column("id", TypeName="smallint")]
    public virtual ushort Id { get; set; }

    [Column("length", TypeName="int")]
    public virtual int Length { get; set; }

    [Column("result", TypeName="tinytext")]
    [MaxLength(255)]
    public virtual string Result { get; set; }

    [Column("str", TypeName="text")]
    [MaxLength(65535)]
    public virtual string Str { get; set; }

    [Column("type", TypeName="int")]
    public virtual int Type { get; set; }

}