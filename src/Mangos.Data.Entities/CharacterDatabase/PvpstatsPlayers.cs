using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.CharacterDatabase;

[Table("pvpstats_players")]
public class PvpstatsPlayers
{
    [Column("attr_1", TypeName="mediumint")]
    public virtual uint Attr1 { get; set; }

    [Column("attr_2", TypeName="mediumint")]
    public virtual uint Attr2 { get; set; }

    [Column("attr_3", TypeName="mediumint")]
    public virtual uint Attr3 { get; set; }

    [Column("attr_4", TypeName="mediumint")]
    public virtual uint Attr4 { get; set; }

    [Column("attr_5", TypeName="mediumint")]
    public virtual uint Attr5 { get; set; }

    [Column("battleground_id", TypeName="bigint")]
    public virtual ulong BattlegroundId { get; set; }

    [Column("character_guid", TypeName="int")]
    public virtual uint CharacterGuid { get; set; }

    [Column("score_bonus_honor", TypeName="mediumint")]
    public virtual uint ScoreBonusHonor { get; set; }

    [Column("score_damage_done", TypeName="mediumint")]
    public virtual uint ScoreDamageDone { get; set; }

    [Column("score_deaths", TypeName="mediumint")]
    public virtual uint ScoreDeaths { get; set; }

    [Column("score_healing_done", TypeName="mediumint")]
    public virtual uint ScoreHealingDone { get; set; }

    [Column("score_honorable_kills", TypeName="mediumint")]
    public virtual uint ScoreHonorableKills { get; set; }

    [Column("score_killing_blows", TypeName="mediumint")]
    public virtual uint ScoreKillingBlows { get; set; }

}