using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("command")]
public class Command
{
    [Column("help", TypeName="longtext")]
    public virtual string Help { get; set; }

    [Column("name")]
    [MaxLength(50)]
    public virtual string Name { get; set; }

    [Column("security", TypeName="tinyint")]
    public virtual byte Security { get; set; }

}