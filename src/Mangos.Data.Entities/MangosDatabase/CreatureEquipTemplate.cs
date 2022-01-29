using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("creature_equip_template")]
public class CreatureEquipTemplate
{
    /* Unique entry */
    [Column("entry", TypeName="mediumint")]
    public virtual uint Entry { get; set; }

    [Column("equipentry1", TypeName="mediumint")]
    public virtual uint Equipentry1 { get; set; }

    [Column("equipentry2", TypeName="mediumint")]
    public virtual uint Equipentry2 { get; set; }

    [Column("equipentry3", TypeName="mediumint")]
    public virtual uint Equipentry3 { get; set; }

}