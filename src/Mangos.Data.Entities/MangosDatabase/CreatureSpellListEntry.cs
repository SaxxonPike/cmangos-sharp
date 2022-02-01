using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("creature_spell_list_entry")]
public class CreatureSpellListEntry
{
    /* Chance of ranged attack per tick */
    [Column("ChanceRangedAttack", TypeName="int")]
    public virtual int ChanceRangedAttack { get; set; }

    /* Chance of support action per tick */
    [Column("ChanceSupportAction", TypeName="int")]
    public virtual int ChanceSupportAction { get; set; }

    /* List ID */
    [Column("Id", TypeName="int")]
    public virtual int Id { get; set; }

    /* Description of usage */
    [Column("Name")]
    [MaxLength(200)]
    public virtual string Name { get; set; }

}