using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.RealmDatabase;

[Table("account_banned")]
public class AccountBanned
{
    /* Account id */
    [Column("account_id", TypeName="int")]
    public virtual int AccountId { get; set; }

    [Column("active", TypeName="tinyint")]
    public virtual sbyte Active { get; set; }

    [Column("banned_at", TypeName="bigint")]
    public virtual long BannedAt { get; set; }

    [Column("banned_by")]
    [MaxLength(50)]
    public virtual string BannedBy { get; set; }

    [Column("expires_at", TypeName="bigint")]
    public virtual long ExpiresAt { get; set; }

    [Column("id", TypeName="int")]
    public virtual int Id { get; set; }

    [Column("reason")]
    [MaxLength(255)]
    public virtual string Reason { get; set; }

    [Column("unbanned_at", TypeName="bigint")]
    public virtual long UnbannedAt { get; set; }

    [Column("unbanned_by")]
    [MaxLength(50)]
    public virtual string UnbannedBy { get; set; }

}