using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.RealmDatabase;

[Table("antispam_blacklist")]
public class AntispamBlacklist
{
    [Column("string", TypeName="varchar")]
    [MaxLength(64)]
    public virtual string String { get; set; }

}