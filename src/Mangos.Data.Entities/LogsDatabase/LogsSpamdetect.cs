using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.LogsDatabase;

[Table("logs_spamdetect")]
public class LogsSpamdetect
{
    [Column("id", TypeName="int")]
    public virtual uint Id { get; set; }

    [Column("time", TypeName="timestamp")]
    public virtual DateTimeOffset Time { get; set; }

    [Column("realm", TypeName="int")]
    public virtual uint Realm { get; set; }

    [Column("accountId", TypeName="int")]
    public virtual int AccountId { get; set; }

    [Column("fromGuid", TypeName="bigint")]
    public virtual ulong FromGuid { get; set; }

    [Column("fromIP")]
    [MaxLength(16)]
    public virtual string FromIp { get; set; }

    [Column("fromFingerprint", TypeName="int")]
    public virtual uint FromFingerprint { get; set; }

    [Column("comment")]
    [MaxLength(8192)]
    public virtual string Comment { get; set; }

}