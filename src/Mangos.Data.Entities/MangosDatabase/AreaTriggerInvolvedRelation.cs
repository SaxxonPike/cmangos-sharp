using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("areatrigger_involvedrelation")]
public class AreaTriggerInvolvedRelation
{
    /* Identifier */
    [Column("id", TypeName="mediumint")]
    public virtual uint Id { get; set; }

    /* Quest Identifier */
    [Column("quest", TypeName="mediumint")]
    public virtual uint Quest { get; set; }

}