using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("creature_cooldowns")]
public class CreatureCooldown
{
    [Column("Entry", TypeName="mediumint")]
    public virtual uint Entry { get; set; }

    [Column("SpellId", TypeName="int")]
    public virtual uint SpellId { get; set; }

    [Column("CooldownMin", TypeName="int")]
    public virtual uint CooldownMin { get; set; }

    [Column("CooldownMax", TypeName="int")]
    public virtual uint CooldownMax { get; set; }

}