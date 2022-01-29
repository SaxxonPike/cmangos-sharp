using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("pickpocketing_loot_template")]
public class PickpocketingLootTemplate
{
    [Column("entry", TypeName="mediumint")]
    public virtual uint Entry { get; set; }

    [Column("item", TypeName="mediumint")]
    public virtual uint Item { get; set; }

    [Column("ChanceOrQuestChance", TypeName="float")]
    public virtual float ChanceOrQuestChance { get; set; }

    [Column("groupid", TypeName="tinyint")]
    public virtual byte Groupid { get; set; }

    [Column("mincountOrRef", TypeName="mediumint")]
    public virtual int MincountOrRef { get; set; }

    [Column("maxcount", TypeName="tinyint")]
    public virtual byte Maxcount { get; set; }

    [Column("condition_id", TypeName="mediumint")]
    public virtual uint ConditionId { get; set; }

    [Column("comments", TypeName="varchar")]
    [MaxLength(300)]
    public virtual string Comments { get; set; }

}