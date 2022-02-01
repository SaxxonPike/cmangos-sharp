using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.CharacterDatabase;

[Table("corpse")]
public class Corpse
{
    [Column("corpse_type", TypeName="tinyint")]
    public virtual byte CorpseType { get; set; }

    /* Global Unique Identifier */
    [Column("guid", TypeName="int")]
    public virtual uint Guid { get; set; }

    [Column("instance", TypeName="int")]
    public virtual uint Instance { get; set; }

    /* Map Identifier */
    [Column("map", TypeName="int")]
    public virtual uint Map { get; set; }

    [Column("orientation", TypeName="float")]
    public virtual float Orientation { get; set; }

    /* Character Global Unique Identifier */
    [Column("player", TypeName="int")]
    public virtual uint Player { get; set; }

    [Column("position_x", TypeName="float")]
    public virtual float PositionX { get; set; }

    [Column("position_y", TypeName="float")]
    public virtual float PositionY { get; set; }

    [Column("position_z", TypeName="float")]
    public virtual float PositionZ { get; set; }

    [Column("time", TypeName="bigint")]
    public virtual ulong Time { get; set; }

}