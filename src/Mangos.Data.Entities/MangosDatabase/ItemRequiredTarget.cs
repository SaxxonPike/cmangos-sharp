using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("item_required_target")]
public class ItemRequiredTarget
{
    [Column("entry", TypeName="mediumint")]
    public virtual uint Entry { get; set; }

    [Column("targetEntry", TypeName="mediumint")]
    public virtual uint TargetEntry { get; set; }

    [Column("type", TypeName="tinyint")]
    public virtual byte Type { get; set; }

}