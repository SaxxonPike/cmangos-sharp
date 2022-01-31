using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.RealmDatabase;

[Table("account_logons")]
public class AccountLogon
{
    [Column("id", TypeName="int")]
    public virtual int Id { get; set; }

    [Column("accountId", TypeName="int")]
    public virtual long AccountId { get; set; }

    [Column("ip")]
    [MaxLength(30)]
    public virtual string Ip { get; set; }

    [Column("loginTime", TypeName="timestamp")]
    public virtual DateTime LoginTime { get; set; }

    [Column("loginSource", TypeName="int")]
    public virtual uint LoginSource { get; set; }

}