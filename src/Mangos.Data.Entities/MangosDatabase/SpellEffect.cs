using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("spell_affect")]
public class SpellEffect
{
    [Column("entry", TypeName="smallint")]
    public virtual uint Entry { get; set; }

    [Column("effectId", TypeName="tinyint")]
    public virtual byte EffectId { get; set; }

    [Column("SpellFamilyMask", TypeName="bigint")]
    public virtual ulong SpellFamilyMask { get; set; }

}