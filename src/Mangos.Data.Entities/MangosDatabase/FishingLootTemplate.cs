using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("fishing_loot_template")]
public class FishingLootTemplate
{
    /* entry 0 used for junk loot at fishing fail (if allowed by config option) */
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

    [Column("comments")]
    [MaxLength(300)]
    public virtual string Comments { get; set; }

}