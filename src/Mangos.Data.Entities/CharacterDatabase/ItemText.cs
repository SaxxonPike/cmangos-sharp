using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.CharacterDatabase;

[Table("item_text")]
public class ItemText
{
    [Column("id", TypeName="int")]
    public virtual uint Id { get; set; }

    [Column("text", TypeName="longtext")]
    public virtual string Text { get; set; }

}