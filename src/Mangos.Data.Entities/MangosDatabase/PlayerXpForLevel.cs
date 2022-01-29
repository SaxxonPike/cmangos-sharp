using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("player_xp_for_level")]
public class PlayerXpForLevel
{
    [Column("lvl", TypeName="int")]
    public virtual uint Lvl { get; set; }

    [Column("xp_for_next_level", TypeName="int")]
    public virtual uint XpForNextLevel { get; set; }

}