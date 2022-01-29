using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.CharacterDatabase;

[Table("item_loot")]
public class ItemLoot
{
    [Column("guid", TypeName="int")]
    public virtual uint Guid { get; set; }

    [Column("owner_guid", TypeName="int")]
    public virtual uint OwnerGuid { get; set; }

    [Column("itemid", TypeName="int")]
    public virtual uint Itemid { get; set; }

    [Column("amount", TypeName="int")]
    public virtual uint Amount { get; set; }

    [Column("property", TypeName="int")]
    public virtual int Property { get; set; }

}