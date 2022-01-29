using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.RealmDatabase;

[Table("ip_banned")]
public class IpBanned
{
    [Column("ip", TypeName="varchar")]
    [MaxLength(32)]
    public virtual string Ip { get; set; }

    [Column("banned_at", TypeName="bigint")]
    public virtual long BannedAt { get; set; }

    [Column("expires_at", TypeName="bigint")]
    public virtual long ExpiresAt { get; set; }

    [Column("banned_by", TypeName="varchar")]
    [MaxLength(50)]
    public virtual string BannedBy { get; set; }

    [Column("reason", TypeName="varchar")]
    [MaxLength(255)]
    public virtual string Reason { get; set; }

}