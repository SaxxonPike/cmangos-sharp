using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.RealmDatabase;

[Table("system_fingerprint_usage")]
public class SystemFingerprintUsage
{
    [Column("id", TypeName="int")]
    public virtual uint Id { get; set; }

    [Column("fingerprint", TypeName="int")]
    public virtual uint Fingerprint { get; set; }

    [Column("account", TypeName="int")]
    public virtual uint Account { get; set; }

    [Column("ip")]
    [MaxLength(16)]
    public virtual string Ip { get; set; }

    [Column("realm", TypeName="int")]
    public virtual uint Realm { get; set; }

    [Column("time", TypeName="datetime")]
    public virtual DateTime Time { get; set; }

    [Column("architecture")]
    [MaxLength(16)]
    public virtual string Architecture { get; set; }

    [Column("cputype")]
    [MaxLength(64)]
    public virtual string Cputype { get; set; }

    [Column("activecpus", TypeName="int")]
    public virtual uint Activecpus { get; set; }

    [Column("totalcpus", TypeName="int")]
    public virtual uint Totalcpus { get; set; }

    [Column("pagesize", TypeName="int")]
    public virtual uint Pagesize { get; set; }

}