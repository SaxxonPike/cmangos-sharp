using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.CharacterDatabase;

[Table("character_inventory")]
public class CharacterInventory
{
    [Column("bag", TypeName="int")]
    public virtual uint Bag { get; set; }

    /* Global Unique Identifier */
    [Column("guid", TypeName="int")]
    public virtual uint Guid { get; set; }

    /* Item Global Unique Identifier */
    [Column("item", TypeName="int")]
    public virtual uint Item { get; set; }

    /* Item Identifier */
    [Column("item_template", TypeName="int")]
    public virtual uint ItemTemplate { get; set; }

    [Column("slot", TypeName="tinyint")]
    public virtual byte Slot { get; set; }

}