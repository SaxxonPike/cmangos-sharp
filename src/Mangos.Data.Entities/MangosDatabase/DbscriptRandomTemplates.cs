using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("dbscript_random_templates")]
public class DbscriptRandomTemplates
{
    /* Chance for element to occur in % */
    [Column("chance", TypeName="int")]
    public virtual int Chance { get; set; }

    [Column("comments")]
    [MaxLength(500)]
    public virtual string Comments { get; set; }

    /* Id of template */
    [Column("id", TypeName="int")]
    public virtual uint Id { get; set; }

    /* Id of chanced element */
    [Column("target_id", TypeName="int")]
    public virtual int TargetId { get; set; }

    /* Type of template */
    [Column("type", TypeName="int")]
    public virtual uint Type { get; set; }

}