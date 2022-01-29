using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("exploration_basexp")]
public class ExplorationBaseXp
{
    [Column("level", TypeName="tinyint")]
    public virtual int Level { get; set; }

    [Column("basexp", TypeName="mediumint")]
    public virtual int Basexp { get; set; }

}