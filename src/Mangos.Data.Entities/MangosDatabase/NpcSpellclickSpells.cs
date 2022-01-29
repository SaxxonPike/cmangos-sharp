using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("npc_spellclick_spells")]
public class NpcSpellclickSpells
{
    /* reference to creature_template */
    [Column("npc_entry", TypeName="int")]
    public virtual uint NpcEntry { get; set; }

    /* spell which should be casted  */
    [Column("spell_id", TypeName="int")]
    public virtual uint SpellId { get; set; }

    /* reference to quest_template */
    [Column("quest_start", TypeName="mediumint")]
    public virtual uint QuestStart { get; set; }

    [Column("quest_start_active", TypeName="tinyint")]
    public virtual byte QuestStartActive { get; set; }

    [Column("quest_end", TypeName="mediumint")]
    public virtual uint QuestEnd { get; set; }

    /* first bit defines caster: 1=player, 0=creature; second bit defines target, same mapping as caster bit */
    [Column("cast_flags", TypeName="tinyint")]
    public virtual byte CastFlags { get; set; }

    [Column("condition_id", TypeName="mediumint")]
    public virtual uint ConditionId { get; set; }

}