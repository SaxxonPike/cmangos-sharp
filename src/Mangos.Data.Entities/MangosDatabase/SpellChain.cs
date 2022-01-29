using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("spell_chain")]
public class SpellChain
{
    [Column("spell_id", TypeName="mediumint")]
    public virtual int SpellId { get; set; }

    [Column("prev_spell", TypeName="mediumint")]
    public virtual int PrevSpell { get; set; }

    [Column("first_spell", TypeName="mediumint")]
    public virtual int FirstSpell { get; set; }

    [Column("rank", TypeName="tinyint")]
    public virtual int Rank { get; set; }

    [Column("req_spell", TypeName="mediumint")]
    public virtual int ReqSpell { get; set; }

}