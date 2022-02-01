using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("dbscript_string_template")]
public class DbscriptStringTemplate
{
    /* Id of template */
    [Column("id", TypeName="int")]
    public virtual uint Id { get; set; }

    /* dbscript_string id */
    [Column("string_id", TypeName="int")]
    public virtual int StringId { get; set; }

}