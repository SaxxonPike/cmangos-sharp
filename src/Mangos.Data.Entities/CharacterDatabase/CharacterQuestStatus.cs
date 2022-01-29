using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.CharacterDatabase;

[Table("character_queststatus")]
public class CharacterQuestStatus
{
    /* Global Unique Identifier */
    [Column("guid", TypeName="int")]
    public virtual uint Guid { get; set; }

    /* Quest Identifier */
    [Column("quest", TypeName="int")]
    public virtual uint Quest { get; set; }

    [Column("status", TypeName="int")]
    public virtual uint Status { get; set; }

    [Column("rewarded", TypeName="tinyint")]
    public virtual byte Rewarded { get; set; }

    [Column("explored", TypeName="tinyint")]
    public virtual byte Explored { get; set; }

    [Column("timer", TypeName="bigint")]
    public virtual ulong Timer { get; set; }

    [Column("mobcount1", TypeName="int")]
    public virtual uint Mobcount1 { get; set; }

    [Column("mobcount2", TypeName="int")]
    public virtual uint Mobcount2 { get; set; }

    [Column("mobcount3", TypeName="int")]
    public virtual uint Mobcount3 { get; set; }

    [Column("mobcount4", TypeName="int")]
    public virtual uint Mobcount4 { get; set; }

    [Column("itemcount1", TypeName="int")]
    public virtual uint Itemcount1 { get; set; }

    [Column("itemcount2", TypeName="int")]
    public virtual uint Itemcount2 { get; set; }

    [Column("itemcount3", TypeName="int")]
    public virtual uint Itemcount3 { get; set; }

    [Column("itemcount4", TypeName="int")]
    public virtual uint Itemcount4 { get; set; }

}