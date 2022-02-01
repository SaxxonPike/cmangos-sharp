using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("npc_trainer_template")]
public class NpcTrainerTemplate
{
    [Column("condition_id", TypeName="int")]
    public virtual uint ConditionId { get; set; }

    [Column("entry", TypeName="mediumint")]
    public virtual uint Entry { get; set; }

    [Column("reqlevel", TypeName="tinyint")]
    public virtual byte Reqlevel { get; set; }

    [Column("reqskill", TypeName="smallint")]
    public virtual ushort Reqskill { get; set; }

    [Column("reqskillvalue", TypeName="smallint")]
    public virtual ushort Reqskillvalue { get; set; }

    [Column("spell", TypeName="mediumint")]
    public virtual uint Spell { get; set; }

    [Column("spellcost", TypeName="int")]
    public virtual uint Spellcost { get; set; }

}