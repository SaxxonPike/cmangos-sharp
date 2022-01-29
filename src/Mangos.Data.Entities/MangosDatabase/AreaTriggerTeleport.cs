using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("areatrigger_teleport")]
public class AreaTriggerTeleport
{
    /* Identifier */
    [Column("id", TypeName="mediumint")]
    public virtual uint Id { get; set; }

    [Column("name", TypeName="text")]
    [MaxLength(65535)]
    public virtual string Name { get; set; }

    [Column("required_level", TypeName="tinyint")]
    public virtual byte RequiredLevel { get; set; }

    [Column("required_item", TypeName="mediumint")]
    public virtual uint RequiredItem { get; set; }

    [Column("required_item2", TypeName="mediumint")]
    public virtual uint RequiredItem2 { get; set; }

    [Column("required_quest_done", TypeName="int")]
    public virtual uint RequiredQuestDone { get; set; }

    [Column("target_map", TypeName="smallint")]
    public virtual uint TargetMap { get; set; }

    [Column("target_position_x", TypeName="float")]
    public virtual float TargetPositionX { get; set; }

    [Column("target_position_y", TypeName="float")]
    public virtual float TargetPositionY { get; set; }

    [Column("target_position_z", TypeName="float")]
    public virtual float TargetPositionZ { get; set; }

    [Column("target_orientation", TypeName="float")]
    public virtual float TargetOrientation { get; set; }

    [Column("status_failed_text", TypeName="text")]
    [MaxLength(65535)]
    public virtual string StatusFailedText { get; set; }

    [Column("condition_id", TypeName="int")]
    public virtual uint ConditionId { get; set; }

}