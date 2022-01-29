using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("spell_pet_auras")]
public class SpellPetAuras
{
    /* dummy spell id */
    [Column("spell", TypeName="mediumint")]
    public virtual uint Spell { get; set; }

    /* pet id; 0 = all */
    [Column("pet", TypeName="mediumint")]
    public virtual uint Pet { get; set; }

    /* pet aura id */
    [Column("aura", TypeName="mediumint")]
    public virtual uint Aura { get; set; }

}