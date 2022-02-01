using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.CharacterDatabase;

[Table("guild")]
public class Guild
{
    [Column("BackgroundColor", TypeName="int")]
    public virtual int BackgroundColor { get; set; }

    [Column("BorderColor", TypeName="int")]
    public virtual int BorderColor { get; set; }

    [Column("BorderStyle", TypeName="int")]
    public virtual int BorderStyle { get; set; }

    [Column("createdate", TypeName="bigint")]
    public virtual ulong Createdate { get; set; }

    [Column("EmblemColor", TypeName="int")]
    public virtual int EmblemColor { get; set; }

    [Column("EmblemStyle", TypeName="int")]
    public virtual int EmblemStyle { get; set; }

    [Column("guildid", TypeName="int")]
    public virtual uint Guildid { get; set; }

    [Column("info")]
    [MaxLength(500)]
    public virtual string Info { get; set; }

    [Column("leaderguid", TypeName="int")]
    public virtual uint Leaderguid { get; set; }

    [Column("motd")]
    [MaxLength(128)]
    public virtual string Motd { get; set; }

    [Column("name")]
    [MaxLength(255)]
    public virtual string Name { get; set; }

}