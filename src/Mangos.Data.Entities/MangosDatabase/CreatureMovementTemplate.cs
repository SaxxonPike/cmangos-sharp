using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("creature_movement_template")]
public class CreatureMovementTemplate
{
    [Column("Entry", TypeName="mediumint")]
    public virtual uint Entry { get; set; }

    [Column("PathId", TypeName="int")]
    public virtual uint PathId { get; set; }

    [Column("Point", TypeName="mediumint")]
    public virtual uint Point { get; set; }

    [Column("PositionX", TypeName="float")]
    public virtual float PositionX { get; set; }

    [Column("PositionY", TypeName="float")]
    public virtual float PositionY { get; set; }

    [Column("PositionZ", TypeName="float")]
    public virtual float PositionZ { get; set; }

    [Column("Orientation", TypeName="float")]
    public virtual float Orientation { get; set; }

    [Column("WaitTime", TypeName="int")]
    public virtual uint WaitTime { get; set; }

    [Column("ScriptId", TypeName="mediumint")]
    public virtual uint ScriptId { get; set; }

    [Column("Comment", TypeName="text")]
    [MaxLength(65535)]
    public virtual string Comment { get; set; }

}