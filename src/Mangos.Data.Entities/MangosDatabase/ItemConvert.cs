using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("item_convert")]
public class ItemConvert
{
    [Column("entry", TypeName="mediumint")]
    public virtual uint Entry { get; set; }

    [Column("item", TypeName="mediumint")]
    public virtual uint Item { get; set; }

}