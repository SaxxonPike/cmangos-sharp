using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("instance_template")]
public class InstanceTemplate
{
    [Column("map", TypeName="smallint")]
    public virtual uint Map { get; set; }

    [Column("parent", TypeName="smallint")]
    public virtual uint Parent { get; set; }

    [Column("levelMin", TypeName="tinyint")]
    public virtual byte LevelMin { get; set; }

    [Column("levelMax", TypeName="tinyint")]
    public virtual byte LevelMax { get; set; }

    [Column("maxPlayers", TypeName="tinyint")]
    public virtual byte MaxPlayers { get; set; }

    /* Reset time in days */
    [Column("reset_delay", TypeName="int")]
    public virtual uint ResetDelay { get; set; }

    [Column("ghostEntranceMap", TypeName="smallint")]
    public virtual uint GhostEntranceMap { get; set; }

    [Column("ghostEntranceX", TypeName="float")]
    public virtual float GhostEntranceX { get; set; }

    [Column("ghostEntranceY", TypeName="float")]
    public virtual float GhostEntranceY { get; set; }

    [Column("ScriptName")]
    [MaxLength(128)]
    public virtual string ScriptName { get; set; }

    [Column("mountAllowed", TypeName="tinyint")]
    public virtual byte MountAllowed { get; set; }

}