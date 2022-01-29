using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("reference_loot_template_names")]
public class ReferenceLootTemplateNames
{
    [Column("entry", TypeName="int")]
    public virtual uint Entry { get; set; }

    [Column("name")]
    [MaxLength(255)]
    public virtual string Name { get; set; }

}