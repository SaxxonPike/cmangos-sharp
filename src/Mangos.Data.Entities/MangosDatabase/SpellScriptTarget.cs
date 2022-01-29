using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("spell_script_target")]
public class SpellScriptTarget
{
    [Column("entry", TypeName="mediumint")]
    public virtual uint Entry { get; set; }

    [Column("type", TypeName="tinyint")]
    public virtual byte Type { get; set; }

    [Column("targetEntry", TypeName="mediumint")]
    public virtual uint TargetEntry { get; set; }

    [Column("inverseEffectMask", TypeName="mediumint")]
    public virtual uint InverseEffectMask { get; set; }

}