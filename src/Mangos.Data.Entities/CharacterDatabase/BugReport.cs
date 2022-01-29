using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.CharacterDatabase;

[Table("bugreport")]
public class BugReport
{
    /* Identifier */
    [Column("id", TypeName="int")]
    public virtual int Id { get; set; }

    [Column("type", TypeName="longtext")]
    public virtual string Type { get; set; }

    [Column("content", TypeName="longtext")]
    public virtual string Content { get; set; }

}