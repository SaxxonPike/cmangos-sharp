using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.CharacterDatabase;

[Table("mail")]
public class Mail
{
    /* Identifier */
    [Column("id", TypeName="int")]
    public virtual uint Id { get; set; }

    [Column("messageType", TypeName="tinyint")]
    public virtual byte MessageType { get; set; }

    [Column("stationery", TypeName="tinyint")]
    public virtual int Stationery { get; set; }

    [Column("mailTemplateId", TypeName="mediumint")]
    public virtual uint MailTemplateId { get; set; }

    /* Character Global Unique Identifier */
    [Column("sender", TypeName="int")]
    public virtual uint Sender { get; set; }

    /* Character Global Unique Identifier */
    [Column("receiver", TypeName="int")]
    public virtual uint Receiver { get; set; }

    [Column("subject", TypeName="longtext")]
    public virtual string Subject { get; set; }

    [Column("itemTextId", TypeName="int")]
    public virtual uint ItemTextId { get; set; }

    [Column("has_items", TypeName="tinyint")]
    public virtual byte HasItems { get; set; }

    [Column("expire_time", TypeName="bigint")]
    public virtual ulong ExpireTime { get; set; }

    [Column("deliver_time", TypeName="bigint")]
    public virtual ulong DeliverTime { get; set; }

    [Column("money", TypeName="int")]
    public virtual uint Money { get; set; }

    [Column("cod", TypeName="int")]
    public virtual uint Cod { get; set; }

    [Column("checked", TypeName="tinyint")]
    public virtual byte Checked { get; set; }

}