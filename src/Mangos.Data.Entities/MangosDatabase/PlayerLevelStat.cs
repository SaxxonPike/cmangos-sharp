using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("player_levelstats")]
public class PlayerLevelStat
{
    [Column("race", TypeName="tinyint")]
    public virtual byte Race { get; set; }

    [Column("class", TypeName="tinyint")]
    public virtual byte Class { get; set; }

    [Column("level", TypeName="tinyint")]
    public virtual byte Level { get; set; }

    [Column("str", TypeName="tinyint")]
    public virtual byte Str { get; set; }

    [Column("agi", TypeName="tinyint")]
    public virtual byte Agi { get; set; }

    [Column("sta", TypeName="tinyint")]
    public virtual byte Sta { get; set; }

    [Column("inte", TypeName="tinyint")]
    public virtual byte Inte { get; set; }

    [Column("spi", TypeName="tinyint")]
    public virtual byte Spi { get; set; }

}