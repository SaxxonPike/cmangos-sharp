using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.CharacterDatabase;

[Table("guild_member")]
public class GuildMember
{
    [Column("guid", TypeName="int")]
    public virtual uint Guid { get; set; }

    [Column("guildid", TypeName="int")]
    public virtual uint Guildid { get; set; }

    [Column("offnote")]
    [MaxLength(31)]
    public virtual string Offnote { get; set; }

    [Column("pnote")]
    [MaxLength(31)]
    public virtual string Pnote { get; set; }

    [Column("rank", TypeName="tinyint")]
    public virtual byte Rank { get; set; }

}