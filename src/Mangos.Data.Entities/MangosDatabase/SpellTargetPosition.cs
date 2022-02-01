using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("spell_target_position")]
public class SpellTargetPosition
{
    /* Identifier */
    [Column("id", TypeName="mediumint")]
    public virtual uint Id { get; set; }

    [Column("target_map", TypeName="smallint")]
    public virtual ushort TargetMap { get; set; }

    [Column("target_orientation", TypeName="float")]
    public virtual float TargetOrientation { get; set; }

    [Column("target_position_x", TypeName="float")]
    public virtual float TargetPositionX { get; set; }

    [Column("target_position_y", TypeName="float")]
    public virtual float TargetPositionY { get; set; }

    [Column("target_position_z", TypeName="float")]
    public virtual float TargetPositionZ { get; set; }

}