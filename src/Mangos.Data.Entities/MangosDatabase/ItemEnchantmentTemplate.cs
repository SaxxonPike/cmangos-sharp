using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("item_enchantment_template")]
public class ItemEnchantmentTemplate
{
    [Column("entry", TypeName="mediumint")]
    public virtual uint Entry { get; set; }

    [Column("ench", TypeName="mediumint")]
    public virtual uint Ench { get; set; }

    [Column("chance", TypeName="float")]
    public virtual float Chance { get; set; }

}