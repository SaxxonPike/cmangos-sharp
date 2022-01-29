using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("pool_pool")]
public class PoolPool
{
    [Column("pool_id", TypeName="mediumint")]
    public virtual uint PoolId { get; set; }

    [Column("mother_pool", TypeName="mediumint")]
    public virtual uint MotherPool { get; set; }

    [Column("chance", TypeName="float")]
    public virtual float Chance { get; set; }

    [Column("description", TypeName="varchar")]
    [MaxLength(255)]
    public virtual string Description { get; set; }

}