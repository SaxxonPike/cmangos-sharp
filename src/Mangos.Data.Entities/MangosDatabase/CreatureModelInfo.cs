using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("creature_model_info")]
public class CreatureModelInfo
{
    [Column("modelid", TypeName="mediumint")]
    public virtual uint Modelid { get; set; }

    [Column("bounding_radius", TypeName="float")]
    public virtual float BoundingRadius { get; set; }

    [Column("combat_reach", TypeName="float")]
    public virtual float CombatReach { get; set; }

    /* Default walking speed for any creature with model */
    [Column("SpeedWalk", TypeName="float")]
    public virtual float SpeedWalk { get; set; }

    /* Default running speed for any creature with model */
    [Column("SpeedRun", TypeName="float")]
    public virtual float SpeedRun { get; set; }

    [Column("gender", TypeName="tinyint")]
    public virtual byte Gender { get; set; }

    [Column("modelid_other_gender", TypeName="mediumint")]
    public virtual uint ModelidOtherGender { get; set; }

    [Column("modelid_other_team", TypeName="mediumint")]
    public virtual uint ModelidOtherTeam { get; set; }

}