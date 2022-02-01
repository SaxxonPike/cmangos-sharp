using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("page_text")]
public class PageText
{
    [Column("entry", TypeName="mediumint")]
    public virtual uint Entry { get; set; }

    [Column("next_page", TypeName="mediumint")]
    public virtual uint NextPage { get; set; }

    [Column("text", TypeName="longtext")]
    public virtual string Text { get; set; }

}