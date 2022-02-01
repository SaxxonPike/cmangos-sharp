using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("playercreateinfo_action")]
public class PlayercreateinfoAction
{
    [Column("action", TypeName="int")]
    public virtual uint Action { get; set; }

    [Column("button", TypeName="smallint")]
    public virtual ushort Button { get; set; }

    [Column("Class", TypeName="tinyint")]
    public virtual byte Class { get; set; }

    [Column("race", TypeName="tinyint")]
    public virtual byte Race { get; set; }

    [Column("type", TypeName="smallint")]
    public virtual ushort Type { get; set; }

}