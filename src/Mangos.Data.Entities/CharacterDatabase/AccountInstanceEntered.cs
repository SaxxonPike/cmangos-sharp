using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.CharacterDatabase;

[Table("account_instances_entered")]
public class AccountInstanceEntered
{
    /* Player account */
    [Column("AccountId", TypeName="int")]
    public virtual uint AccountId { get; set; }

    /* Time when instance was entered */
    [Column("ExpireTime", TypeName="bigint")]
    public virtual long ExpireTime { get; set; }

    /* ID of instance entered */
    [Column("InstanceId", TypeName="int")]
    public virtual uint InstanceId { get; set; }

}