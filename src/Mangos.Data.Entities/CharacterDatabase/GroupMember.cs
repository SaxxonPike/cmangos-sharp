using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.CharacterDatabase;

[Table("group_member")]
public class GroupMember
{
    [Column("groupId", TypeName="int")]
    public virtual uint GroupId { get; set; }

    [Column("memberGuid", TypeName="int")]
    public virtual uint MemberGuid { get; set; }

    [Column("assistant", TypeName="tinyint")]
    public virtual byte Assistant { get; set; }

    [Column("subgroup", TypeName="smallint")]
    public virtual uint Subgroup { get; set; }

}