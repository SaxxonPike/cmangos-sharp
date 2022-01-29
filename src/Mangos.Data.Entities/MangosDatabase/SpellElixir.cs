using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("spell_elixir")]
public class SpellElixir
{
    /* SpellId of potion */
    [Column("entry", TypeName="int")]
    public virtual uint Entry { get; set; }

    /* Mask 0x1 battle 0x2 guardian 0x3 flask 0x7 unstable flasks 0xB shattrath flasks */
    [Column("mask", TypeName="tinyint")]
    public virtual byte Mask { get; set; }

}