using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("creature_spell_targeting")]
public class CreatureSpellTargeting
{
    /* Targeting ID */
    [Column("Id", TypeName="int")]
    public virtual int Id { get; set; }

    /* Type of targeting ID */
    [Column("Type", TypeName="int")]
    public virtual int Type { get; set; }

    /* First parameter */
    [Column("Param1", TypeName="int")]
    public virtual int Param1 { get; set; }

    /* Second parameter */
    [Column("Param2", TypeName="int")]
    public virtual int Param2 { get; set; }

    /* Third parameter */
    [Column("Param3", TypeName="int")]
    public virtual int Param3 { get; set; }

    /* Description of target */
    [Column("Comments")]
    [MaxLength(255)]
    public virtual string Comments { get; set; }

}