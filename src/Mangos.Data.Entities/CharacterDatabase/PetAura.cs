using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.CharacterDatabase;

[Table("pet_aura")]
public class PetAura
{
    /* Global Unique Identifier */
    [Column("guid", TypeName="int")]
    public virtual uint Guid { get; set; }

    /* Full Global Unique Identifier */
    [Column("caster_guid", TypeName="bigint")]
    public virtual ulong CasterGuid { get; set; }

    [Column("item_guid", TypeName="int")]
    public virtual uint ItemGuid { get; set; }

    [Column("spell", TypeName="int")]
    public virtual uint Spell { get; set; }

    [Column("stackcount", TypeName="int")]
    public virtual uint Stackcount { get; set; }

    [Column("remaincharges", TypeName="int")]
    public virtual uint Remaincharges { get; set; }

    [Column("basepoints0", TypeName="int")]
    public virtual int Basepoints0 { get; set; }

    [Column("basepoints1", TypeName="int")]
    public virtual int Basepoints1 { get; set; }

    [Column("basepoints2", TypeName="int")]
    public virtual int Basepoints2 { get; set; }

    [Column("periodictime0", TypeName="int")]
    public virtual uint Periodictime0 { get; set; }

    [Column("periodictime1", TypeName="int")]
    public virtual uint Periodictime1 { get; set; }

    [Column("periodictime2", TypeName="int")]
    public virtual uint Periodictime2 { get; set; }

    [Column("maxduration", TypeName="int")]
    public virtual int Maxduration { get; set; }

    [Column("remaintime", TypeName="int")]
    public virtual int Remaintime { get; set; }

    [Column("effIndexMask", TypeName="int")]
    public virtual uint EffIndexMask { get; set; }

}