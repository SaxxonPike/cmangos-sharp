using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.CharacterDatabase;

[Table("mail_items")]
public class MailItems
{
    [Column("item_guid", TypeName="int")]
    public virtual int ItemGuid { get; set; }

    [Column("item_template", TypeName="int")]
    public virtual int ItemTemplate { get; set; }

    [Column("mail_id", TypeName="int")]
    public virtual int MailId { get; set; }

    /* Character Global Unique Identifier */
    [Column("receiver", TypeName="int")]
    public virtual uint Receiver { get; set; }

}