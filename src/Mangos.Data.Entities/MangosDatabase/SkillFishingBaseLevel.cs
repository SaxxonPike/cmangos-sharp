using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("skill_fishing_base_level")]
public class SkillFishingBaseLevel
{
    /* Area identifier */
    [Column("entry", TypeName="mediumint")]
    public virtual uint Entry { get; set; }

    /* Base skill level requirement */
    [Column("skill", TypeName="smallint")]
    public virtual short Skill { get; set; }

}