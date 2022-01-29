using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.CharacterDatabase;

[Table("playerbot_saved_data")]
public class PlayerBotSavedData
{
    [Column("guid", TypeName="int")]
    public virtual uint Guid { get; set; }

    [Column("combat_order", TypeName="tinyint")]
    public virtual byte CombatOrder { get; set; }

    [Column("primary_target", TypeName="int")]
    public virtual uint PrimaryTarget { get; set; }

    [Column("secondary_target", TypeName="int")]
    public virtual uint SecondaryTarget { get; set; }

    [Column("pname")]
    [MaxLength(12)]
    public virtual string Pname { get; set; }

    [Column("sname")]
    [MaxLength(12)]
    public virtual string Sname { get; set; }

    [Column("combat_delay", TypeName="int")]
    public virtual uint CombatDelay { get; set; }

}