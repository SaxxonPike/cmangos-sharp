using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("spell_area")]
public class SpellArea
{
    [Column("area", TypeName="mediumint")]
    public virtual uint Area { get; set; }

    [Column("aura_spell", TypeName="mediumint")]
    public virtual int AuraSpell { get; set; }

    [Column("autocast", TypeName="tinyint")]
    public virtual byte Autocast { get; set; }

    [Column("condition_id", TypeName="mediumint")]
    public virtual uint ConditionId { get; set; }

    [Column("gender", TypeName="tinyint")]
    public virtual byte Gender { get; set; }

    [Column("quest_end", TypeName="mediumint")]
    public virtual uint QuestEnd { get; set; }

    [Column("quest_start", TypeName="mediumint")]
    public virtual uint QuestStart { get; set; }

    [Column("quest_start_active", TypeName="tinyint")]
    public virtual byte QuestStartActive { get; set; }

    [Column("racemask", TypeName="mediumint")]
    public virtual uint Racemask { get; set; }

    [Column("spell", TypeName="mediumint")]
    public virtual uint Spell { get; set; }

}