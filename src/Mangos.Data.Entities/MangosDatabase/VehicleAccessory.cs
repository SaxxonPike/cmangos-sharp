using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("vehicle_accessory")]
public class VehicleAccessory
{
    /* entry of the passenger that is to be boarded */
    [Column("accessory_entry", TypeName="int")]
    public virtual uint AccessoryEntry { get; set; }

    [Column("comment")]
    [MaxLength(255)]
    public virtual string Comment { get; set; }

    /* onto which seat shall the passenger be boarded */
    [Column("seat", TypeName="mediumint")]
    public virtual uint Seat { get; set; }

    /* entry of the npc who has some accessory as vehicle */
    [Column("vehicle_entry", TypeName="int")]
    public virtual uint VehicleEntry { get; set; }

}