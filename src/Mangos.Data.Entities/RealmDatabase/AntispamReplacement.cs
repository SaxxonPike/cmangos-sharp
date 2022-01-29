using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.RealmDatabase;

[Table("antispam_replacement")]
public class AntispamReplacement
{
    [Column("from", TypeName="varchar")]
    [MaxLength(32)]
    public virtual string From { get; set; }

    [Column("to", TypeName="varchar")]
    [MaxLength(32)]
    public virtual string To { get; set; }

}