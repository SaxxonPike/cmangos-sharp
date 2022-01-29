using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("playercreateinfo_action")]
public class PlayerCreateInfoAction
{
    [Column("race", TypeName="tinyint")]
    public virtual byte Race { get; set; }

    [Column("class", TypeName="tinyint")]
    public virtual byte Class { get; set; }

    [Column("button", TypeName="smallint")]
    public virtual uint Button { get; set; }

    [Column("action", TypeName="int")]
    public virtual uint Action { get; set; }

    [Column("type", TypeName="smallint")]
    public virtual uint Type { get; set; }

}