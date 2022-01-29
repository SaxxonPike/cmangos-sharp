using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("creature_template_spells")]
public class CreatureTemplateSpells
{
    [Column("entry", TypeName="mediumint")]
    public virtual uint Entry { get; set; }

    /* Id of set of spells */
    [Column("setId", TypeName="int")]
    public virtual uint SetId { get; set; }

    [Column("spell1", TypeName="mediumint")]
    public virtual uint Spell1 { get; set; }

    [Column("spell2", TypeName="mediumint")]
    public virtual uint Spell2 { get; set; }

    [Column("spell3", TypeName="mediumint")]
    public virtual uint Spell3 { get; set; }

    [Column("spell4", TypeName="mediumint")]
    public virtual uint Spell4 { get; set; }

    [Column("spell5", TypeName="mediumint")]
    public virtual uint Spell5 { get; set; }

    [Column("spell6", TypeName="mediumint")]
    public virtual uint Spell6 { get; set; }

    [Column("spell7", TypeName="mediumint")]
    public virtual uint Spell7 { get; set; }

    [Column("spell8", TypeName="mediumint")]
    public virtual uint Spell8 { get; set; }

    [Column("spell9", TypeName="mediumint")]
    public virtual uint Spell9 { get; set; }

    [Column("spell10", TypeName="mediumint")]
    public virtual uint Spell10 { get; set; }

}