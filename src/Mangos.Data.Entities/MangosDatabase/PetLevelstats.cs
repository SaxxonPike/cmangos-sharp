using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("pet_levelstats")]
public class PetLevelstats
{
    [Column("agi", TypeName="smallint")]
    public virtual ushort Agi { get; set; }

    [Column("armor", TypeName="int")]
    public virtual uint Armor { get; set; }

    [Column("creature_entry", TypeName="mediumint")]
    public virtual uint CreatureEntry { get; set; }

    [Column("hp", TypeName="smallint")]
    public virtual ushort Hp { get; set; }

    [Column("inte", TypeName="smallint")]
    public virtual ushort Inte { get; set; }

    [Column("level", TypeName="tinyint")]
    public virtual byte Level { get; set; }

    [Column("mana", TypeName="smallint")]
    public virtual ushort Mana { get; set; }

    [Column("spi", TypeName="smallint")]
    public virtual ushort Spi { get; set; }

    [Column("sta", TypeName="smallint")]
    public virtual ushort Sta { get; set; }

    [Column("str", TypeName="smallint")]
    public virtual ushort Str { get; set; }

}