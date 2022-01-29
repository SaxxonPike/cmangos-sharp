using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.CharacterDatabase;

[Table("gm_tickets")]
public class GmTicket
{
    /* GM Ticket's unique identifier */
    [Column("id", TypeName="int")]
    public virtual uint Id { get; set; }

    /* GM Ticket Category DBC entry's identifier */
    [Column("category", TypeName="tinyint")]
    public virtual byte Category { get; set; }

    /* Ticket's current state */
    [Column("state", TypeName="tinyint")]
    public virtual byte State { get; set; }

    /* Ticket's current status */
    [Column("status", TypeName="tinyint")]
    public virtual byte Status { get; set; }

    /* Ticket's security level */
    [Column("level", TypeName="tinyint")]
    public virtual byte Level { get; set; }

    /* Player's character Global Unique Identifier */
    [Column("author_guid", TypeName="int")]
    public virtual uint AuthorGuid { get; set; }

    /* Player's character name */
    [Column("author_name")]
    [MaxLength(12)]
    public virtual string AuthorName { get; set; }

    /* Player's client locale name */
    [Column("locale")]
    [MaxLength(4)]
    public virtual string Locale { get; set; }

    /* Character's map identifier on submission */
    [Column("mapid", TypeName="int")]
    public virtual uint Mapid { get; set; }

    /* Character's x coordinate on submission */
    [Column("x", TypeName="float")]
    public virtual float X { get; set; }

    /* Character's y coordinate on submission */
    [Column("y", TypeName="float")]
    public virtual float Y { get; set; }

    /* Character's z coordinate on submission */
    [Column("z", TypeName="float")]
    public virtual float Z { get; set; }

    /* Character's orientation angle on submission */
    [Column("o", TypeName="float")]
    public virtual float O { get; set; }

    /* Ticket's message */
    [Column("text", TypeName="text")]
    [MaxLength(65535)]
    public virtual string Text { get; set; }

    /* Timestamp: ticket created by a player */
    [Column("created", TypeName="bigint")]
    public virtual ulong Created { get; set; }

    /* Timestamp: ticket text's last update */
    [Column("updated", TypeName="bigint")]
    public virtual ulong Updated { get; set; }

    /* Timestamp: ticket's last time opened by a GM */
    [Column("seen", TypeName="bigint")]
    public virtual ulong Seen { get; set; }

    /* Timestamp: ticket's last time answered by a GM */
    [Column("answered", TypeName="bigint")]
    public virtual ulong Answered { get; set; }

    /* Timestamp: ticket closed by a GM */
    [Column("closed", TypeName="bigint")]
    public virtual ulong Closed { get; set; }

    /* Assignee's character's Global Unique Identifier */
    [Column("assignee_guid", TypeName="int")]
    public virtual uint AssigneeGuid { get; set; }

    /* Assignee's character's name */
    [Column("assignee_name")]
    [MaxLength(12)]
    public virtual string AssigneeName { get; set; }

    /* Assignee's final conclusion on this ticket */
    [Column("conclusion")]
    [MaxLength(255)]
    public virtual string Conclusion { get; set; }

    /* Additional notes for GMs */
    [Column("notes")]
    [MaxLength(10000)]
    public virtual string Notes { get; set; }

}