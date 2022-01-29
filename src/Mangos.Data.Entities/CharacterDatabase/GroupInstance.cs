using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.CharacterDatabase;

[Table("group_instance")]
public class GroupInstance
{
    [Column("leaderGuid", TypeName="int")]
    public virtual uint LeaderGuid { get; set; }

    [Column("instance", TypeName="int")]
    public virtual uint Instance { get; set; }

    [Column("permanent", TypeName="tinyint")]
    public virtual byte Permanent { get; set; }

}