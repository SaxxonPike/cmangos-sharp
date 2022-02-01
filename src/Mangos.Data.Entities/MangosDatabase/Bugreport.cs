using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("bugreport")]
public class Bugreport
{
    [Column("content", TypeName="longtext")]
    public virtual string Content { get; set; }

    /* Identifier */
    [Column("id", TypeName="int")]
    public virtual int Id { get; set; }

    [Column("type", TypeName="longtext")]
    public virtual string Type { get; set; }

}