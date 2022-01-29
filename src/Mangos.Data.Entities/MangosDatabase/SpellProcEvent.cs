using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("spell_proc_event")]
public class SpellProcEvent
{
    [Column("entry", TypeName="mediumint")]
    public virtual uint Entry { get; set; }

    [Column("SchoolMask", TypeName="tinyint")]
    public virtual byte SchoolMask { get; set; }

    [Column("SpellFamilyName", TypeName="smallint")]
    public virtual uint SpellFamilyName { get; set; }

    [Column("SpellFamilyMask0", TypeName="bigint")]
    public virtual ulong SpellFamilyMask0 { get; set; }

    [Column("SpellFamilyMask1", TypeName="bigint")]
    public virtual ulong SpellFamilyMask1 { get; set; }

    [Column("SpellFamilyMask2", TypeName="bigint")]
    public virtual ulong SpellFamilyMask2 { get; set; }

    [Column("procFlags", TypeName="int")]
    public virtual uint ProcFlags { get; set; }

    [Column("procEx", TypeName="int")]
    public virtual uint ProcEx { get; set; }

    [Column("ppmRate", TypeName="float")]
    public virtual float PpmRate { get; set; }

    [Column("CustomChance", TypeName="float")]
    public virtual float CustomChance { get; set; }

    [Column("Cooldown", TypeName="int")]
    public virtual uint Cooldown { get; set; }

}