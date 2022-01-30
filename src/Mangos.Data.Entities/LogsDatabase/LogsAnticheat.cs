using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.LogsDatabase;

[Table("logs_anticheat")]
public class LogsAnticheat
{
    [Column("id", TypeName="int")]
    public virtual uint Id { get; set; }

    [Column("time", TypeName="datetime")]
    public virtual DateTimeOffset Time { get; set; }

    [Column("realm", TypeName="int")]
    public virtual uint Realm { get; set; }

    [Column("account", TypeName="int")]
    public virtual uint Account { get; set; }

    [Column("ip")]
    [MaxLength(16)]
    public virtual string Ip { get; set; }

    [Column("fingerprint", TypeName="int")]
    public virtual uint Fingerprint { get; set; }

    [Column("actionMask", TypeName="int")]
    public virtual uint ActionMask { get; set; }

    [Column("player")]
    [MaxLength(32)]
    public virtual string Player { get; set; }

    [Column("info")]
    [MaxLength(512)]
    public virtual string Info { get; set; }

}