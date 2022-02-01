using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.RealmDatabase;

[Table("uptime")]
public class Uptime
{
    [Column("maxplayers", TypeName="smallint")]
    public virtual ushort Maxplayers { get; set; }

    [Column("realmid", TypeName="int")]
    public virtual uint Realmid { get; set; }

    [Column("startstring")]
    [MaxLength(64)]
    public virtual string Startstring { get; set; }

    [Column("starttime", TypeName="bigint")]
    public virtual ulong Starttime { get; set; }

    [Column("uptime", TypeName="bigint")]
    public virtual ulong UpTime { get; set; }

}