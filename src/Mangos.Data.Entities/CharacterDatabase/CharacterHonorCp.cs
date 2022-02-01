using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.CharacterDatabase;

[Table("character_honor_cp")]
public class CharacterHonorCp
{
    [Column("date", TypeName="int")]
    public virtual uint Date { get; set; }

    /* Global Unique Identifier */
    [Column("guid", TypeName="int")]
    public virtual uint Guid { get; set; }

    [Column("honor", TypeName="float")]
    public virtual float Honor { get; set; }

    [Column("type", TypeName="tinyint")]
    public virtual byte Type { get; set; }

    /* Creature / Player Identifier */
    [Column("victim", TypeName="int")]
    public virtual uint Victim { get; set; }

    [Column("victim_type", TypeName="tinyint")]
    public virtual byte VictimType { get; set; }

}