using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.CharacterDatabase;

[Table("character_gifts")]
public class CharacterGifts
{
    [Column("entry", TypeName="int")]
    public virtual uint Entry { get; set; }

    [Column("flags", TypeName="int")]
    public virtual uint Flags { get; set; }

    [Column("guid", TypeName="int")]
    public virtual uint Guid { get; set; }

    [Column("item_guid", TypeName="int")]
    public virtual uint ItemGuid { get; set; }

}