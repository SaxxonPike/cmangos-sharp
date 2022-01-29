using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("item_expire_convert")]
public class ItemExpireConvert
{
    [Column("entry", TypeName="mediumint")]
    public virtual uint Entry { get; set; }

    [Column("item", TypeName="mediumint")]
    public virtual uint Item { get; set; }

}