using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("spell_affect")]
public class SpellAffect
{
    [Column("effectId", TypeName="tinyint")]
    public virtual byte EffectId { get; set; }

    [Column("entry", TypeName="smallint")]
    public virtual ushort Entry { get; set; }

    [Column("SpellFamilyMask", TypeName="bigint")]
    public virtual ulong SpellFamilyMask { get; set; }

}