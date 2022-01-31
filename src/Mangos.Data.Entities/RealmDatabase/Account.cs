using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.RealmDatabase;

[Table("account")]
public class Account
{
    /* Identifier */
    [Column("id", TypeName="int")]
    public virtual long Id { get; set; }

    [Column("username")]
    [MaxLength(32)]
    public virtual string Username { get; set; }

    [Column("gmlevel", TypeName="tinyint")]
    public virtual byte Gmlevel { get; set; }

    [Column("sessionkey", TypeName="longtext")]
    public virtual string Sessionkey { get; set; }

    [Column("v", TypeName="longtext")]
    public virtual string V { get; set; }

    [Column("s", TypeName="longtext")]
    public virtual string S { get; set; }

    [Column("email", TypeName="text")]
    [MaxLength(65535)]
    public virtual string Email { get; set; }

    [Column("joindate", TypeName="timestamp")]
    public virtual DateTime Joindate { get; set; }

    [Column("lockedIp")]
    [MaxLength(30)]
    public virtual string LockedIp { get; set; }

    [Column("failed_logins", TypeName="int")]
    public virtual uint FailedLogins { get; set; }

    [Column("locked", TypeName="tinyint")]
    public virtual byte Locked { get; set; }

    [Column("last_module")]
    [MaxLength(32)]
    public virtual string LastModule { get; set; }

    [Column("module_day", TypeName="mediumint")]
    public virtual uint ModuleDay { get; set; }

    [Column("active_realm_id", TypeName="int")]
    public virtual uint ActiveRealmId { get; set; }

    [Column("expansion", TypeName="tinyint")]
    public virtual byte Expansion { get; set; }

    [Column("mutetime", TypeName="bigint")]
    public virtual ulong Mutetime { get; set; }

    [Column("locale")]
    [MaxLength(4)]
    public virtual string Locale { get; set; }

    [Column("os")]
    [MaxLength(4)]
    public virtual string Os { get; set; }

    [Column("token", TypeName="text")]
    [MaxLength(65535)]
    public virtual string Token { get; set; }

    [Column("flags", TypeName="int")]
    public virtual uint Flags { get; set; }

}