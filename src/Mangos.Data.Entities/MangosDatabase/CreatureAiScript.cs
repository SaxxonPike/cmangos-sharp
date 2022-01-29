using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("creature_ai_scripts")]
public class CreatureAiScript
{
    /* Identifier */
    [Column("id", TypeName="int")]
    public virtual uint Id { get; set; }

    /* Creature Template Identifier */
    [Column("creature_id", TypeName="int")]
    public virtual uint CreatureId { get; set; }

    /* Event Type */
    [Column("event_type", TypeName="tinyint")]
    public virtual byte EventType { get; set; }

    /* Mask which phases this event will not trigger in */
    [Column("event_inverse_phase_mask", TypeName="int")]
    public virtual int EventInversePhaseMask { get; set; }

    [Column("event_chance", TypeName="int")]
    public virtual uint EventChance { get; set; }

    [Column("event_flags", TypeName="int")]
    public virtual uint EventFlags { get; set; }

    [Column("event_param1", TypeName="int")]
    public virtual int EventParam1 { get; set; }

    [Column("event_param2", TypeName="int")]
    public virtual int EventParam2 { get; set; }

    [Column("event_param3", TypeName="int")]
    public virtual int EventParam3 { get; set; }

    [Column("event_param4", TypeName="int")]
    public virtual int EventParam4 { get; set; }

    [Column("event_param5", TypeName="int")]
    public virtual int EventParam5 { get; set; }

    [Column("event_param6", TypeName="int")]
    public virtual int EventParam6 { get; set; }

    /* Action Type */
    [Column("action1_type", TypeName="tinyint")]
    public virtual byte Action1Type { get; set; }

    [Column("action1_param1", TypeName="int")]
    public virtual int Action1Param1 { get; set; }

    [Column("action1_param2", TypeName="int")]
    public virtual int Action1Param2 { get; set; }

    [Column("action1_param3", TypeName="int")]
    public virtual int Action1Param3 { get; set; }

    /* Action Type */
    [Column("action2_type", TypeName="tinyint")]
    public virtual byte Action2Type { get; set; }

    [Column("action2_param1", TypeName="int")]
    public virtual int Action2Param1 { get; set; }

    [Column("action2_param2", TypeName="int")]
    public virtual int Action2Param2 { get; set; }

    [Column("action2_param3", TypeName="int")]
    public virtual int Action2Param3 { get; set; }

    /* Action Type */
    [Column("action3_type", TypeName="tinyint")]
    public virtual byte Action3Type { get; set; }

    [Column("action3_param1", TypeName="int")]
    public virtual int Action3Param1 { get; set; }

    [Column("action3_param2", TypeName="int")]
    public virtual int Action3Param2 { get; set; }

    [Column("action3_param3", TypeName="int")]
    public virtual int Action3Param3 { get; set; }

    /* Event Comment */
    [Column("comment", TypeName="varchar")]
    [MaxLength(255)]
    public virtual string Comment { get; set; }

}