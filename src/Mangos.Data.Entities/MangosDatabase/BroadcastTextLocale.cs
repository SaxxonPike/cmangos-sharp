using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("broadcast_text_locale")]
public class BroadcastTextLocale
{
    /* Identifier */
    [Column("Id", TypeName="int")]
    public virtual int Id { get; set; }

    /* Locale */
    [Column("Locale")]
    [MaxLength(10)]
    public virtual string Locale { get; set; }

    /* Female text */
    [Column("Text1_lang", TypeName="text")]
    [MaxLength(65535)]
    public virtual string Text1Lang { get; set; }

    /* Male text */
    [Column("Text_lang", TypeName="text")]
    [MaxLength(65535)]
    public virtual string TextLang { get; set; }

    /* Build of bruteforce */
    [Column("VerifiedBuild", TypeName="int")]
    public virtual int VerifiedBuild { get; set; }

}