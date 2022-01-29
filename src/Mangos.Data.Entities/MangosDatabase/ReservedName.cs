using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("reserved_name")]
public class ReservedName
{
    [Column("name")]
    [MaxLength(12)]
    public virtual string Name { get; set; }

}