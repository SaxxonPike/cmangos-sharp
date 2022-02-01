using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("creature")]
public class Creature
{
    [Column("curhealth", TypeName="int")]
    public virtual uint Curhealth { get; set; }

    [Column("curmana", TypeName="int")]
    public virtual uint Curmana { get; set; }

    [Column("currentwaypoint", TypeName="mediumint")]
    public virtual uint Currentwaypoint { get; set; }

    [Column("DeathState", TypeName="tinyint")]
    public virtual byte DeathState { get; set; }

    [Column("equipment_id", TypeName="mediumint")]
    public virtual int EquipmentId { get; set; }

    /* Global Unique Identifier */
    [Column("guid", TypeName="int")]
    public virtual uint Guid { get; set; }

    /* Creature Identifier */
    [Column("id", TypeName="mediumint")]
    public virtual uint Id { get; set; }

    /* Map Identifier */
    [Column("map", TypeName="smallint")]
    public virtual ushort Map { get; set; }

    [Column("modelid", TypeName="mediumint")]
    public virtual uint Modelid { get; set; }

    [Column("MovementType", TypeName="tinyint")]
    public virtual byte MovementType { get; set; }

    [Column("orientation", TypeName="float")]
    public virtual float Orientation { get; set; }

    [Column("position_x", TypeName="float")]
    public virtual float PositionX { get; set; }

    [Column("position_y", TypeName="float")]
    public virtual float PositionY { get; set; }

    [Column("position_z", TypeName="float")]
    public virtual float PositionZ { get; set; }

    [Column("spawndist", TypeName="float")]
    public virtual float Spawndist { get; set; }

    [Column("spawnMask", TypeName="tinyint")]
    public virtual byte SpawnMask { get; set; }

    /* Creature respawn time maximum */
    [Column("spawntimesecsmax", TypeName="int")]
    public virtual uint Spawntimesecsmax { get; set; }

    /* Creature respawn time minimum */
    [Column("spawntimesecsmin", TypeName="int")]
    public virtual uint Spawntimesecsmin { get; set; }

}