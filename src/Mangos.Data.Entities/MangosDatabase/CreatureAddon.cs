using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("creature_addon")]
public class CreatureAddon
{
    [Column("guid", TypeName="int")]
    public virtual uint Guid { get; set; }

    [Column("mount", TypeName="mediumint")]
    public virtual uint Mount { get; set; }

    [Column("bytes1", TypeName="int")]
    public virtual uint Bytes1 { get; set; }

    [Column("b2_0_sheath", TypeName="tinyint")]
    public virtual byte B20Sheath { get; set; }

    [Column("b2_1_flags", TypeName="tinyint")]
    public virtual byte B21Flags { get; set; }

    [Column("emote", TypeName="int")]
    public virtual uint Emote { get; set; }

    [Column("moveflags", TypeName="int")]
    public virtual uint Moveflags { get; set; }

    [Column("auras", TypeName="text")]
    [MaxLength(65535)]
    public virtual string Auras { get; set; }

}