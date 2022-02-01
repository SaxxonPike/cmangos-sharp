using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.CharacterDatabase;

[Table("group_member")]
public class GroupMember
{
    [Column("assistant", TypeName="tinyint")]
    public virtual byte Assistant { get; set; }

    [Column("groupId", TypeName="int")]
    public virtual uint GroupId { get; set; }

    [Column("memberGuid", TypeName="int")]
    public virtual uint MemberGuid { get; set; }

    [Column("subgroup", TypeName="smallint")]
    public virtual ushort Subgroup { get; set; }

}