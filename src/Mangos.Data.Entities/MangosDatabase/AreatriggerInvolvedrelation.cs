using System.ComponentModel.DataAnnotations.Schema;

// ReSharper disable StringLiteralTypo
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable CommentTypo

namespace Mangos.Data.Entities.MangosDatabase;

[Table("areatrigger_involvedrelation")]
public class AreatriggerInvolvedrelation
{
    /* Identifier */
    [Column("id", TypeName="mediumint")]
    public virtual uint Id { get; set; }

    /* Quest Identifier */
    [Column("quest", TypeName="mediumint")]
    public virtual uint Quest { get; set; }

}