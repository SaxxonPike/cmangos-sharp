using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("creature_spawn_data_template")]
public class CreatureSpawnDataTemplate
{
    [Column("CurHealth", TypeName="int")]
    public virtual uint CurHealth { get; set; }

    [Column("CurMana", TypeName="int")]
    public virtual uint CurMana { get; set; }

    /* ID of template */
    [Column("Entry", TypeName="int")]
    public virtual uint Entry { get; set; }

    [Column("EquipmentId", TypeName="mediumint")]
    public virtual int EquipmentId { get; set; }

    [Column("Faction", TypeName="int")]
    public virtual uint Faction { get; set; }

    [Column("ModelId", TypeName="mediumint")]
    public virtual uint ModelId { get; set; }

    /* dbscripts_on_relay */
    [Column("RelayId", TypeName="int")]
    public virtual uint RelayId { get; set; }

    [Column("SpawnFlags", TypeName="int")]
    public virtual uint SpawnFlags { get; set; }

    [Column("UnitFlags", TypeName="bigint")]
    public virtual long UnitFlags { get; set; }

}