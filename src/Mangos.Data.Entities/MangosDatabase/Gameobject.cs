using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("gameobject")]
public class Gameobject
{
    [Column("animprogress", TypeName="tinyint")]
    public virtual byte Animprogress { get; set; }

    /* Global Unique Identifier */
    [Column("guid", TypeName="int")]
    public virtual uint Guid { get; set; }

    /* Gameobject Identifier */
    [Column("id", TypeName="mediumint")]
    public virtual uint Id { get; set; }

    /* Map Identifier */
    [Column("map", TypeName="smallint")]
    public virtual ushort Map { get; set; }

    [Column("orientation", TypeName="float")]
    public virtual float Orientation { get; set; }

    [Column("position_x", TypeName="float")]
    public virtual float PositionX { get; set; }

    [Column("position_y", TypeName="float")]
    public virtual float PositionY { get; set; }

    [Column("position_z", TypeName="float")]
    public virtual float PositionZ { get; set; }

    [Column("rotation0", TypeName="float")]
    public virtual float Rotation0 { get; set; }

    [Column("rotation1", TypeName="float")]
    public virtual float Rotation1 { get; set; }

    [Column("rotation2", TypeName="float")]
    public virtual float Rotation2 { get; set; }

    [Column("rotation3", TypeName="float")]
    public virtual float Rotation3 { get; set; }

    [Column("spawnMask", TypeName="tinyint")]
    public virtual byte SpawnMask { get; set; }

    /* Gameobject respawn time maximum */
    [Column("spawntimesecsmax", TypeName="int")]
    public virtual int Spawntimesecsmax { get; set; }

    /* Gameobject respawn time minimum */
    [Column("spawntimesecsmin", TypeName="int")]
    public virtual int Spawntimesecsmin { get; set; }

    [Column("state", TypeName="tinyint")]
    public virtual byte State { get; set; }

}