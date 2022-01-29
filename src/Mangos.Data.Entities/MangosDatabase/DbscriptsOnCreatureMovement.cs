using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("dbscripts_on_creature_movement")]
public class DbscriptsOnCreatureMovement
{
    [Column("id", TypeName="mediumint")]
    public virtual uint Id { get; set; }

    [Column("delay", TypeName="int")]
    public virtual uint Delay { get; set; }

    [Column("priority", TypeName="int")]
    public virtual uint Priority { get; set; }

    [Column("command", TypeName="mediumint")]
    public virtual uint Command { get; set; }

    [Column("datalong", TypeName="int")]
    public virtual uint Datalong { get; set; }

    [Column("datalong2", TypeName="int")]
    public virtual uint Datalong2 { get; set; }

    [Column("datalong3", TypeName="int")]
    public virtual uint Datalong3 { get; set; }

    [Column("buddy_entry", TypeName="mediumint")]
    public virtual uint BuddyEntry { get; set; }

    [Column("search_radius", TypeName="mediumint")]
    public virtual uint SearchRadius { get; set; }

    [Column("data_flags", TypeName="int")]
    public virtual uint DataFlags { get; set; }

    [Column("dataint", TypeName="int")]
    public virtual int Dataint { get; set; }

    [Column("dataint2", TypeName="int")]
    public virtual int Dataint2 { get; set; }

    [Column("dataint3", TypeName="int")]
    public virtual int Dataint3 { get; set; }

    [Column("dataint4", TypeName="int")]
    public virtual int Dataint4 { get; set; }

    [Column("x", TypeName="float")]
    public virtual float X { get; set; }

    [Column("y", TypeName="float")]
    public virtual float Y { get; set; }

    [Column("z", TypeName="float")]
    public virtual float Z { get; set; }

    [Column("o", TypeName="float")]
    public virtual float O { get; set; }

    [Column("condition_id", TypeName="mediumint")]
    public virtual uint ConditionId { get; set; }

    [Column("comments")]
    [MaxLength(255)]
    public virtual string Comments { get; set; }

}