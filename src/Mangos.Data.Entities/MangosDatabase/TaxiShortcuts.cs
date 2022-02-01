using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("taxi_shortcuts")]
public class TaxiShortcuts
{
    [Column("comments")]
    [MaxLength(255)]
    public virtual string Comments { get; set; }

    /* Amount of waypoints to skip at the end of the flight */
    [Column("landing", TypeName="int")]
    public virtual uint Landing { get; set; }

    /* Flight path entry id */
    [Column("pathid", TypeName="int")]
    public virtual uint Pathid { get; set; }

    /* Amount of waypoints to skip in the beginning of the flight */
    [Column("takeoff", TypeName="int")]
    public virtual uint Takeoff { get; set; }

}