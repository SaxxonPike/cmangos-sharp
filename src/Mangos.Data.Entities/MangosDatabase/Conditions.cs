using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("conditions")]
public class Conditions
{
    /* Identifier */
    [Column("condition_entry", TypeName="mediumint")]
    public virtual uint ConditionEntry { get; set; }

    /* Type of the condition */
    [Column("type", TypeName="tinyint")]
    public virtual int Type { get; set; }

    /* data field one for the condition */
    [Column("value1", TypeName="mediumint")]
    public virtual uint Value1 { get; set; }

    /* data field two for the condition */
    [Column("value2", TypeName="mediumint")]
    public virtual uint Value2 { get; set; }

    /* data field three for the condition */
    [Column("value3", TypeName="mediumint")]
    public virtual uint Value3 { get; set; }

    /* data field four for the condition */
    [Column("value4", TypeName="mediumint")]
    public virtual uint Value4 { get; set; }

    [Column("flags", TypeName="tinyint")]
    public virtual byte Flags { get; set; }

    [Column("comments", TypeName="varchar")]
    [MaxLength(500)]
    public virtual string Comments { get; set; }

}