using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("petcreateinfo_spell")]
public class PetcreateinfoSpell
{
    [Column("entry", TypeName="mediumint")]
    public virtual uint Entry { get; set; }

    [Column("Spell1", TypeName="mediumint")]
    public virtual uint Spell1 { get; set; }

    [Column("Spell2", TypeName="mediumint")]
    public virtual uint Spell2 { get; set; }

    [Column("Spell3", TypeName="mediumint")]
    public virtual uint Spell3 { get; set; }

    [Column("Spell4", TypeName="mediumint")]
    public virtual uint Spell4 { get; set; }

}