using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("transports")]
public class Transport
{
    [Column("entry", TypeName="mediumint")]
    public virtual uint Entry { get; set; }

    [Column("name", TypeName="text")]
    [MaxLength(65535)]
    public virtual string Name { get; set; }

    [Column("period", TypeName="mediumint")]
    public virtual uint Period { get; set; }

}