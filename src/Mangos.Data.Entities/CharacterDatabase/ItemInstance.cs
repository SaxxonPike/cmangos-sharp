using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.CharacterDatabase;

[Table("item_instance")]
public class ItemInstance
{
    [Column("charges", TypeName="text")]
    [MaxLength(65535)]
    public virtual string Charges { get; set; }

    [Column("count", TypeName="int")]
    public virtual uint Count { get; set; }

    [Column("creatorGuid", TypeName="int")]
    public virtual uint CreatorGuid { get; set; }

    [Column("durability", TypeName="int")]
    public virtual uint Durability { get; set; }

    [Column("duration", TypeName="int")]
    public virtual uint Duration { get; set; }

    [Column("enchantments", TypeName="text")]
    [MaxLength(65535)]
    public virtual string Enchantments { get; set; }

    [Column("flags", TypeName="int")]
    public virtual uint Flags { get; set; }

    [Column("giftCreatorGuid", TypeName="int")]
    public virtual uint GiftCreatorGuid { get; set; }

    [Column("guid", TypeName="int")]
    public virtual uint Guid { get; set; }

    [Column("itemEntry", TypeName="mediumint")]
    public virtual uint ItemEntry { get; set; }

    [Column("itemTextId", TypeName="mediumint")]
    public virtual uint ItemTextId { get; set; }

    [Column("owner_guid", TypeName="int")]
    public virtual uint OwnerGuid { get; set; }

    [Column("randomPropertyId", TypeName="smallint")]
    public virtual short RandomPropertyId { get; set; }

}