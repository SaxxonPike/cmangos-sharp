using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("pet_familystats")]
public class PetFamilyStats
{
    [Column("family", TypeName="mediumint")]
    public virtual uint Family { get; set; }

    [Column("healthModifier", TypeName="float")]
    public virtual float HealthModifier { get; set; }

    [Column("damageModifier", TypeName="float")]
    public virtual float DamageModifier { get; set; }

    [Column("armorModifier", TypeName="float")]
    public virtual float ArmorModifier { get; set; }

}