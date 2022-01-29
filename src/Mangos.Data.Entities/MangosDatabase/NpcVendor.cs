using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("npc_vendor")]
public class NpcVendor
{
    [Column("entry", TypeName="mediumint")]
    public virtual uint Entry { get; set; }

    [Column("item", TypeName="mediumint")]
    public virtual uint Item { get; set; }

    [Column("maxcount", TypeName="tinyint")]
    public virtual byte Maxcount { get; set; }

    [Column("incrtime", TypeName="int")]
    public virtual uint Incrtime { get; set; }

    [Column("condition_id", TypeName="mediumint")]
    public virtual uint ConditionId { get; set; }

    [Column("comments", TypeName="text")]
    [MaxLength(65535)]
    public virtual string Comments { get; set; }

}