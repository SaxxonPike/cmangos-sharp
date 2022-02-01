using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("spell_chain")]
public class SpellChain
{
    [Column("first_spell", TypeName="mediumint")]
    public virtual int FirstSpell { get; set; }

    [Column("prev_spell", TypeName="mediumint")]
    public virtual int PrevSpell { get; set; }

    [Column("rank", TypeName="tinyint")]
    public virtual sbyte Rank { get; set; }

    [Column("req_spell", TypeName="mediumint")]
    public virtual int ReqSpell { get; set; }

    [Column("spell_id", TypeName="mediumint")]
    public virtual int SpellId { get; set; }

}