using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("playercreateinfo_skills")]
public class PlayerCreateInfoSkills
{
    [Column("raceMask", TypeName="int")]
    public virtual uint RaceMask { get; set; }

    [Column("classMask", TypeName="int")]
    public virtual uint ClassMask { get; set; }

    [Column("skill", TypeName="smallint")]
    public virtual uint Skill { get; set; }

    [Column("step", TypeName="smallint")]
    public virtual uint Step { get; set; }

    [Column("note")]
    [MaxLength(255)]
    public virtual string Note { get; set; }

}