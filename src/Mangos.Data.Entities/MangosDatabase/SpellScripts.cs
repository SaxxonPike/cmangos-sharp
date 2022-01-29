using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("spell_scripts")]
public class SpellScripts
{
    /* Spell ID */
    [Column("Id", TypeName="int")]
    public virtual int Id { get; set; }

    /* Core Spell Script Name */
    [Column("ScriptName")]
    [MaxLength(64)]
    public virtual string ScriptName { get; set; }

}