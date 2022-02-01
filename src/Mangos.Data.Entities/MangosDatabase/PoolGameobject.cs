using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("pool_gameobject")]
public class PoolGameobject
{
    [Column("chance", TypeName="float")]
    public virtual float Chance { get; set; }

    [Column("description")]
    [MaxLength(255)]
    public virtual string Description { get; set; }

    [Column("guid", TypeName="int")]
    public virtual uint Guid { get; set; }

    [Column("pool_entry", TypeName="mediumint")]
    public virtual uint PoolEntry { get; set; }

}