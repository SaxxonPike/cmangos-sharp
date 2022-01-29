using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("spam_records")]
public class SpamRecords
{
    [Column("id", TypeName="int")]
    public virtual int Id { get; set; }

    [Column("record", TypeName="varchar")]
    [MaxLength(512)]
    public virtual string Record { get; set; }

}