using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("playercreateinfo_skills")]
public class PlayercreateinfoSkills
{
    [Column("classMask", TypeName="int")]
    public virtual uint ClassMask { get; set; }

    [Column("note")]
    [MaxLength(255)]
    public virtual string Note { get; set; }

    [Column("raceMask", TypeName="int")]
    public virtual uint RaceMask { get; set; }

    [Column("skill", TypeName="smallint")]
    public virtual ushort Skill { get; set; }

    [Column("step", TypeName="smallint")]
    public virtual ushort Step { get; set; }

}