using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("playercreateinfo_item")]
public class PlayerCreateInfoItem
{
    [Column("race", TypeName="tinyint")]
    public virtual byte Race { get; set; }

    [Column("class", TypeName="tinyint")]
    public virtual byte Class { get; set; }

    [Column("itemid", TypeName="mediumint")]
    public virtual uint Itemid { get; set; }

    [Column("amount", TypeName="tinyint")]
    public virtual byte Amount { get; set; }

}