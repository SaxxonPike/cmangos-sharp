using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("db_version")]
public class DbVersion
{
    [Column("version", TypeName="varchar")]
    [MaxLength(120)]
    public virtual string Version { get; set; }

    [Column("creature_ai_version", TypeName="varchar")]
    [MaxLength(120)]
    public virtual string CreatureAiVersion { get; set; }

    [Column("required_z2785_01_mangos_waypoint_path", TypeName="bit")]
    public virtual bool RequiredZ278501MangosWaypointPath { get; set; }

}