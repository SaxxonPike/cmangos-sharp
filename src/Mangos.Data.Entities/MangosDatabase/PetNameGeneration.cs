using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("pet_name_generation")]
public class PetNameGeneration
{
    [Column("id", TypeName="mediumint")]
    public virtual uint Id { get; set; }

    [Column("word", TypeName="tinytext")]
    [MaxLength(255)]
    public virtual string Word { get; set; }

    [Column("entry", TypeName="mediumint")]
    public virtual uint Entry { get; set; }

    [Column("half", TypeName="tinyint")]
    public virtual int Half { get; set; }

}