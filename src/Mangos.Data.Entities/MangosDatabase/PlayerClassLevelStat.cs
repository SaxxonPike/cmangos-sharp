using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("player_classlevelstats")]
public class PlayerClassLevelStat
{
    [Column("class", TypeName="tinyint")]
    public virtual byte Class { get; set; }

    [Column("level", TypeName="tinyint")]
    public virtual byte Level { get; set; }

    [Column("basehp", TypeName="smallint")]
    public virtual uint Basehp { get; set; }

    [Column("basemana", TypeName="smallint")]
    public virtual uint Basemana { get; set; }

}