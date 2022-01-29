using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("pet_levelstats_copy")]
public class PetLevelStatsCopy
{
    [Column("creature_entry", TypeName="mediumint")]
    public virtual uint CreatureEntry { get; set; }

    [Column("level", TypeName="tinyint")]
    public virtual byte Level { get; set; }

    [Column("hp", TypeName="smallint")]
    public virtual uint Hp { get; set; }

    [Column("mana", TypeName="smallint")]
    public virtual uint Mana { get; set; }

    [Column("armor", TypeName="int")]
    public virtual uint Armor { get; set; }

    [Column("str", TypeName="smallint")]
    public virtual uint Str { get; set; }

    [Column("agi", TypeName="smallint")]
    public virtual uint Agi { get; set; }

    [Column("sta", TypeName="smallint")]
    public virtual uint Sta { get; set; }

    [Column("inte", TypeName="smallint")]
    public virtual uint Inte { get; set; }

    [Column("spi", TypeName="smallint")]
    public virtual uint Spi { get; set; }

}