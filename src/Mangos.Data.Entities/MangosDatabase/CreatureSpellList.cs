using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("creature_spell_list")]
public class CreatureSpellList
{
    /* List ID */
    [Column("Id", TypeName="int")]
    public virtual int Id { get; set; }

    /* Position on list */
    [Column("Position", TypeName="int")]
    public virtual int Position { get; set; }

    /* Spell ID */
    [Column("SpellId", TypeName="int")]
    public virtual int SpellId { get; set; }

    /* Spell Flags */
    [Column("Flags", TypeName="int")]
    public virtual int Flags { get; set; }

    /* Targeting ID */
    [Column("TargetId", TypeName="int")]
    public virtual int TargetId { get; set; }

    /* Dbscript to be launched on success */
    [Column("ScriptId", TypeName="int")]
    public virtual int ScriptId { get; set; }

    /* Chance on spawn for spell to be included */
    [Column("Availability", TypeName="int")]
    public virtual int Availability { get; set; }

    /* Weight of spell when multiple are available */
    [Column("Probability", TypeName="int")]
    public virtual int Probability { get; set; }

    /* Initial delay minimum */
    [Column("InitialMin", TypeName="int")]
    public virtual int InitialMin { get; set; }

    /* Initial delay maximum */
    [Column("InitialMax", TypeName="int")]
    public virtual int InitialMax { get; set; }

    /* Repeated delay minimum */
    [Column("RepeatMin", TypeName="int")]
    public virtual int RepeatMin { get; set; }

    /* Repeated delay maximum */
    [Column("RepeatMax", TypeName="int")]
    public virtual int RepeatMax { get; set; }

    /* Description of spell use */
    [Column("Comments", TypeName="varchar")]
    [MaxLength(255)]
    public virtual string Comments { get; set; }

}