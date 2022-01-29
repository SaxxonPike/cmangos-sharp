using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.CharacterDatabase;

[Table("petition_sign")]
public class PetitionSign
{
    [Column("ownerguid", TypeName="int")]
    public virtual uint Ownerguid { get; set; }

    [Column("petitionguid", TypeName="int")]
    public virtual uint Petitionguid { get; set; }

    [Column("playerguid", TypeName="int")]
    public virtual uint Playerguid { get; set; }

    [Column("player_account", TypeName="int")]
    public virtual uint PlayerAccount { get; set; }

}