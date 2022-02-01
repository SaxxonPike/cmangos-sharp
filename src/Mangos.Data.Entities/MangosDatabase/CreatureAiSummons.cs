using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("creature_ai_summons")]
public class CreatureAiSummons
{
    /* Summon Comment */
    [Column("comment")]
    [MaxLength(255)]
    public virtual string Comment { get; set; }

    /* Location Identifier */
    [Column("id", TypeName="int")]
    public virtual uint Id { get; set; }

    [Column("orientation", TypeName="float")]
    public virtual float Orientation { get; set; }

    [Column("position_x", TypeName="float")]
    public virtual float PositionX { get; set; }

    [Column("position_y", TypeName="float")]
    public virtual float PositionY { get; set; }

    [Column("position_z", TypeName="float")]
    public virtual float PositionZ { get; set; }

    [Column("spawntimesecs", TypeName="int")]
    public virtual uint Spawntimesecs { get; set; }

}