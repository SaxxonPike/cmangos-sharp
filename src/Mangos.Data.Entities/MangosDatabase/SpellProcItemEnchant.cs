using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("spell_proc_item_enchant")]
public class SpellProcItemEnchant
{
    [Column("entry", TypeName="mediumint")]
    public virtual uint Entry { get; set; }

    [Column("ppmRate", TypeName="float")]
    public virtual float PpmRate { get; set; }

}