using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.CharacterDatabase;

[Table("guild_rank")]
public class GuildRank
{
    [Column("guildid", TypeName="int")]
    public virtual uint Guildid { get; set; }

    [Column("rid", TypeName="int")]
    public virtual uint Rid { get; set; }

    [Column("rname")]
    [MaxLength(255)]
    public virtual string Rname { get; set; }

    [Column("rights", TypeName="int")]
    public virtual uint Rights { get; set; }

}