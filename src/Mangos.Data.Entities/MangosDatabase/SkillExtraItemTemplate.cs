using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("skill_extra_item_template")]
public class SkillExtraItemTemplate
{
    /* chance to create add */
    [Column("additionalCreateChance", TypeName="float")]
    public virtual float AdditionalCreateChance { get; set; }

    /* max num of adds */
    [Column("additionalMaxNum", TypeName="tinyint")]
    public virtual byte AdditionalMaxNum { get; set; }

    /* Specialization spell id */
    [Column("requiredSpecialization", TypeName="mediumint")]
    public virtual uint RequiredSpecialization { get; set; }

    /* SpellId of the item creation spell */
    [Column("spellId", TypeName="mediumint")]
    public virtual uint SpellId { get; set; }

}