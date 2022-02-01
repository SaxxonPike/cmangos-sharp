using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("player_classlevelstats")]
public class PlayerClasslevelstats
{
    [Column("basehp", TypeName="smallint")]
    public virtual ushort Basehp { get; set; }

    [Column("basemana", TypeName="smallint")]
    public virtual ushort Basemana { get; set; }

    [Column("Class", TypeName="tinyint")]
    public virtual byte Class { get; set; }

    [Column("level", TypeName="tinyint")]
    public virtual byte Level { get; set; }

}