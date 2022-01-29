using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.CharacterDatabase;

[Table("character_tutorial")]
public class CharacterTutorial
{
    /* Account Identifier */
    [Column("account", TypeName="bigint")]
    public virtual ulong Account { get; set; }

    [Column("tut0", TypeName="int")]
    public virtual uint Tut0 { get; set; }

    [Column("tut1", TypeName="int")]
    public virtual uint Tut1 { get; set; }

    [Column("tut2", TypeName="int")]
    public virtual uint Tut2 { get; set; }

    [Column("tut3", TypeName="int")]
    public virtual uint Tut3 { get; set; }

    [Column("tut4", TypeName="int")]
    public virtual uint Tut4 { get; set; }

    [Column("tut5", TypeName="int")]
    public virtual uint Tut5 { get; set; }

    [Column("tut6", TypeName="int")]
    public virtual uint Tut6 { get; set; }

    [Column("tut7", TypeName="int")]
    public virtual uint Tut7 { get; set; }

}