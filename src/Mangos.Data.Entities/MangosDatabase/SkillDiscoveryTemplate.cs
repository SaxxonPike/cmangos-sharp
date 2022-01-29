using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("skill_discovery_template")]
public class SkillDiscoveryTemplate
{
    /* SpellId of the discoverable spell */
    [Column("spellId", TypeName="mediumint")]
    public virtual uint SpellId { get; set; }

    /* spell requirement */
    [Column("reqSpell", TypeName="mediumint")]
    public virtual uint ReqSpell { get; set; }

    /* skill points requirement */
    [Column("reqSkillValue", TypeName="smallint")]
    public virtual uint ReqSkillValue { get; set; }

    /* chance to discover */
    [Column("chance", TypeName="float")]
    public virtual float Chance { get; set; }

}