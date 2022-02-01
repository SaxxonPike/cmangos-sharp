using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("game_event_mail")]
public class GameEventMail
{
    /* Negatives value to send at event stop, positive value for send at event start. */
    [Column("Event", TypeName="smallint")]
    public virtual short Event { get; set; }

    [Column("mailTemplateId", TypeName="mediumint")]
    public virtual uint MailTemplateId { get; set; }

    [Column("quest", TypeName="mediumint")]
    public virtual uint Quest { get; set; }

    [Column("raceMask", TypeName="mediumint")]
    public virtual uint RaceMask { get; set; }

    [Column("senderEntry", TypeName="mediumint")]
    public virtual uint SenderEntry { get; set; }

}