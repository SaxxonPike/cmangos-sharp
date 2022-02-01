using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.CharacterDatabase;

[Table("groups")]
public class Groups
{
    [Column("groupId", TypeName="int")]
    public virtual uint GroupId { get; set; }

    [Column("icon1", TypeName="int")]
    public virtual uint Icon1 { get; set; }

    [Column("icon2", TypeName="int")]
    public virtual uint Icon2 { get; set; }

    [Column("icon3", TypeName="int")]
    public virtual uint Icon3 { get; set; }

    [Column("icon4", TypeName="int")]
    public virtual uint Icon4 { get; set; }

    [Column("icon5", TypeName="int")]
    public virtual uint Icon5 { get; set; }

    [Column("icon6", TypeName="int")]
    public virtual uint Icon6 { get; set; }

    [Column("icon7", TypeName="int")]
    public virtual uint Icon7 { get; set; }

    [Column("icon8", TypeName="int")]
    public virtual uint Icon8 { get; set; }

    [Column("isRaid", TypeName="tinyint")]
    public virtual byte IsRaid { get; set; }

    [Column("leaderGuid", TypeName="int")]
    public virtual uint LeaderGuid { get; set; }

    [Column("looterGuid", TypeName="int")]
    public virtual uint LooterGuid { get; set; }

    [Column("lootMethod", TypeName="tinyint")]
    public virtual byte LootMethod { get; set; }

    [Column("lootThreshold", TypeName="tinyint")]
    public virtual byte LootThreshold { get; set; }

    [Column("mainAssistant", TypeName="int")]
    public virtual uint MainAssistant { get; set; }

    [Column("mainTank", TypeName="int")]
    public virtual uint MainTank { get; set; }

}