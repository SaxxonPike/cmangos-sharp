using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("game_event_creature_data")]
public class GameEventCreatureData
{
    [Column("guid", TypeName="int")]
    public virtual uint Guid { get; set; }

    [Column("entry_id", TypeName="mediumint")]
    public virtual uint EntryId { get; set; }

    [Column("modelid", TypeName="mediumint")]
    public virtual uint Modelid { get; set; }

    [Column("equipment_id", TypeName="mediumint")]
    public virtual uint EquipmentId { get; set; }

    [Column("spell_start", TypeName="mediumint")]
    public virtual uint SpellStart { get; set; }

    [Column("spell_end", TypeName="mediumint")]
    public virtual uint SpellEnd { get; set; }

    [Column("event", TypeName="smallint")]
    public virtual uint Event { get; set; }

}