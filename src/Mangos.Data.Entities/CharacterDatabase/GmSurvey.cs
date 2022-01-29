using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.CharacterDatabase;

[Table("gm_surveys")]
public class GmSurvey
{
    /* GM Ticket's unique identifier */
    [Column("ticketid", TypeName="int")]
    public virtual uint Ticketid { get; set; }

    /* Survey DBC entry's identifier */
    [Column("surveyid", TypeName="int")]
    public virtual uint Surveyid { get; set; }

    [Column("answer1", TypeName="tinyint")]
    public virtual byte Answer1 { get; set; }

    [Column("answer2", TypeName="tinyint")]
    public virtual byte Answer2 { get; set; }

    [Column("answer3", TypeName="tinyint")]
    public virtual byte Answer3 { get; set; }

    [Column("answer4", TypeName="tinyint")]
    public virtual byte Answer4 { get; set; }

    [Column("answer5", TypeName="tinyint")]
    public virtual byte Answer5 { get; set; }

    [Column("answer6", TypeName="tinyint")]
    public virtual byte Answer6 { get; set; }

    [Column("answer7", TypeName="tinyint")]
    public virtual byte Answer7 { get; set; }

    [Column("answer8", TypeName="tinyint")]
    public virtual byte Answer8 { get; set; }

    [Column("answer9", TypeName="tinyint")]
    public virtual byte Answer9 { get; set; }

    [Column("answer10", TypeName="tinyint")]
    public virtual byte Answer10 { get; set; }

    /* Player's feedback */
    [Column("comment", TypeName="text")]
    [MaxLength(65535)]
    public virtual string Comment { get; set; }

}