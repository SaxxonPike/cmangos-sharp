using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("exploration_basexp")]
public class ExplorationBasexp
{
    [Column("basexp", TypeName="mediumint")]
    public virtual int Basexp { get; set; }

    [Column("level", TypeName="tinyint")]
    public virtual sbyte Level { get; set; }

}