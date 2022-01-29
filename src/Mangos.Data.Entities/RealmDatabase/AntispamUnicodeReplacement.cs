using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.RealmDatabase;

[Table("antispam_unicode_replacement")]
public class AntispamUnicodeReplacement
{
    [Column("from", TypeName="mediumint")]
    public virtual uint From { get; set; }

    [Column("to", TypeName="mediumint")]
    public virtual uint To { get; set; }

}