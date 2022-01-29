using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.RealmDatabase;

[Table("uptime")]
public class Uptime
{
    [Column("realmid", TypeName="int")]
    public virtual uint Realmid { get; set; }

    [Column("starttime", TypeName="bigint")]
    public virtual ulong Starttime { get; set; }

    [Column("startstring", TypeName="varchar")]
    [MaxLength(64)]
    public virtual string Startstring { get; set; }

    [Column("uptime", TypeName="bigint")]
    public virtual ulong Time { get; set; }

    [Column("maxplayers", TypeName="smallint")]
    public virtual uint Maxplayers { get; set; }

}