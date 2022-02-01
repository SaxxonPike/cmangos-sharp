using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("mail_level_reward")]
public class MailLevelReward
{
    [Column("level", TypeName="tinyint")]
    public virtual byte Level { get; set; }

    [Column("mailTemplateId", TypeName="mediumint")]
    public virtual uint MailTemplateId { get; set; }

    [Column("raceMask", TypeName="mediumint")]
    public virtual uint RaceMask { get; set; }

    [Column("senderEntry", TypeName="mediumint")]
    public virtual uint SenderEntry { get; set; }

}