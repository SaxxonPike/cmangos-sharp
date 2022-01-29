using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.CharacterDatabase;

[Table("character_pet")]
public class CharacterPet
{
    [Column("id", TypeName="int")]
    public virtual uint Id { get; set; }

    [Column("entry", TypeName="int")]
    public virtual uint Entry { get; set; }

    [Column("owner", TypeName="int")]
    public virtual uint Owner { get; set; }

    [Column("modelid", TypeName="int")]
    public virtual uint Modelid { get; set; }

    [Column("CreatedBySpell", TypeName="int")]
    public virtual uint CreatedBySpell { get; set; }

    [Column("PetType", TypeName="tinyint")]
    public virtual byte PetType { get; set; }

    [Column("level", TypeName="int")]
    public virtual uint Level { get; set; }

    [Column("exp", TypeName="int")]
    public virtual uint Exp { get; set; }

    [Column("Reactstate", TypeName="tinyint")]
    public virtual byte Reactstate { get; set; }

    [Column("loyaltypoints", TypeName="int")]
    public virtual int Loyaltypoints { get; set; }

    [Column("loyalty", TypeName="int")]
    public virtual uint Loyalty { get; set; }

    [Column("xpForNextLoyalty", TypeName="int")]
    public virtual uint XpForNextLoyalty { get; set; }

    [Column("trainpoint", TypeName="int")]
    public virtual int Trainpoint { get; set; }

    [Column("name")]
    [MaxLength(100)]
    public virtual string Name { get; set; }

    [Column("renamed", TypeName="tinyint")]
    public virtual byte Renamed { get; set; }

    [Column("slot", TypeName="int")]
    public virtual uint Slot { get; set; }

    [Column("curhealth", TypeName="int")]
    public virtual uint Curhealth { get; set; }

    [Column("curmana", TypeName="int")]
    public virtual uint Curmana { get; set; }

    [Column("curhappiness", TypeName="int")]
    public virtual uint Curhappiness { get; set; }

    [Column("savetime", TypeName="bigint")]
    public virtual ulong Savetime { get; set; }

    [Column("resettalents_cost", TypeName="int")]
    public virtual uint ResettalentsCost { get; set; }

    [Column("resettalents_time", TypeName="bigint")]
    public virtual ulong ResettalentsTime { get; set; }

    [Column("abdata", TypeName="longtext")]
    public virtual string Abdata { get; set; }

    [Column("teachspelldata", TypeName="longtext")]
    public virtual string Teachspelldata { get; set; }

}