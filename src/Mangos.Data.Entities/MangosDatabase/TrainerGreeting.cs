using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("trainer_greeting")]
public class TrainerGreeting
{
    /* Entry of Trainer */
    [Column("Entry", TypeName="int")]
    public virtual uint Entry { get; set; }

    /* Text of the greeting */
    [Column("Text", TypeName="longtext")]
    public virtual string Text { get; set; }

}