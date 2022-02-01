using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("player_levelstats")]
public class PlayerLevelstats
{
    [Column("agi", TypeName="tinyint")]
    public virtual byte Agi { get; set; }

    [Column("Class", TypeName="tinyint")]
    public virtual byte Class { get; set; }

    [Column("inte", TypeName="tinyint")]
    public virtual byte Inte { get; set; }

    [Column("level", TypeName="tinyint")]
    public virtual byte Level { get; set; }

    [Column("race", TypeName="tinyint")]
    public virtual byte Race { get; set; }

    [Column("spi", TypeName="tinyint")]
    public virtual byte Spi { get; set; }

    [Column("sta", TypeName="tinyint")]
    public virtual byte Sta { get; set; }

    [Column("str", TypeName="tinyint")]
    public virtual byte Str { get; set; }

}