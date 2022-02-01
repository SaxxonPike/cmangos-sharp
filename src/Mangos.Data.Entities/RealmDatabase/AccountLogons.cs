using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.RealmDatabase;

[Table("account_logons")]
public class AccountLogons
{
    [Column("accountId", TypeName="int")]
    public virtual uint AccountId { get; set; }

    [Column("id", TypeName="int")]
    public virtual int Id { get; set; }

    [Column("ip")]
    [MaxLength(30)]
    public virtual string Ip { get; set; }

    [Column("loginSource", TypeName="int")]
    public virtual uint LoginSource { get; set; }

    [Column("loginTime", TypeName="timestamp")]
    public virtual DateTimeOffset LoginTime { get; set; }

}