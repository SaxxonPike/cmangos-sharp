using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("reputation_reward_rate")]
public class ReputationRewardRate
{
    [Column("faction", TypeName="mediumint")]
    public virtual uint Faction { get; set; }

    [Column("quest_rate", TypeName="float")]
    public virtual float QuestRate { get; set; }

    [Column("creature_rate", TypeName="float")]
    public virtual float CreatureRate { get; set; }

    [Column("spell_rate", TypeName="float")]
    public virtual float SpellRate { get; set; }

}