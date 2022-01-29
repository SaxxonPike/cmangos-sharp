using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("pool_template")]
public class PoolTemplate
{
    /* Pool entry */
    [Column("entry", TypeName="mediumint")]
    public virtual uint Entry { get; set; }

    /* Max number of objects (0) is no limit */
    [Column("max_limit", TypeName="int")]
    public virtual uint MaxLimit { get; set; }

    [Column("description", TypeName="varchar")]
    [MaxLength(255)]
    public virtual string Description { get; set; }

}