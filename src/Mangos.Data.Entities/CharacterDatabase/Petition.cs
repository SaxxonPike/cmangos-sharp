using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.CharacterDatabase;

[Table("petition")]
public class Petition
{
    [Column("ownerguid", TypeName="int")]
    public virtual uint Ownerguid { get; set; }

    [Column("petitionguid", TypeName="int")]
    public virtual uint Petitionguid { get; set; }

    [Column("name")]
    [MaxLength(255)]
    public virtual string Name { get; set; }

}