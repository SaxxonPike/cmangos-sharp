/* THIS FILE IS AUTOMATICALLY GENERATED */

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// ReSharper disable All

namespace Mangos.Data.Entities.LogsDatabase;

[Table("logs_anticheat")]
public class LogsAnticheat
{
    [Column("account", TypeName="int")]
    public virtual uint Account { get; set; }

    [Column("actionMask", TypeName="int")]
    public virtual uint ActionMask { get; set; }

    [Column("fingerprint", TypeName="int")]
    public virtual uint Fingerprint { get; set; }

    [Column("id", TypeName="int")]
    public virtual uint Id { get; set; }

    [Column("info")]
    [MaxLength(512)]
    public virtual string Info { get; set; }

    [Column("ip")]
    [MaxLength(16)]
    public virtual string Ip { get; set; }

    [Column("player")]
    [MaxLength(32)]
    public virtual string Player { get; set; }

    [Column("realm", TypeName="int")]
    public virtual uint Realm { get; set; }

    [Column("time", TypeName="datetime")]
    public virtual DateTimeOffset Time { get; set; }

}
[Table("logs_spamdetect")]
public class LogsSpamdetect
{
    [Column("accountId", TypeName="int")]
    public virtual int AccountId { get; set; }

    [Column("comment")]
    [MaxLength(8192)]
    public virtual string Comment { get; set; }

    [Column("fromFingerprint", TypeName="int")]
    public virtual uint FromFingerprint { get; set; }

    [Column("fromGuid", TypeName="bigint")]
    public virtual ulong FromGuid { get; set; }

    [Column("fromIP")]
    [MaxLength(16)]
    public virtual string FromIP { get; set; }

    [Column("id", TypeName="int")]
    public virtual uint Id { get; set; }

    [Column("realm", TypeName="int")]
    public virtual uint Realm { get; set; }

    [Column("time", TypeName="timestamp")]
    public virtual DateTimeOffset Time { get; set; }

}
