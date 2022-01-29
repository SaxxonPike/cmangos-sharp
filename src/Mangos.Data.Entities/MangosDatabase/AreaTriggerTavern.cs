using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("areatrigger_tavern")]
public class AreaTriggerTavern
{
    /* Identifier */
    [Column("id", TypeName="mediumint")]
    public virtual uint Id { get; set; }

    [Column("name", TypeName="text")]
    [MaxLength(65535)]
    public virtual string Name { get; set; }

}