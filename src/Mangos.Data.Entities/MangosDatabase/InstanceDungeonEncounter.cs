using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("instance_dungeon_encounters")]
public class InstanceDungeonEncounter
{
    [Column("Id", TypeName="int")]
    public virtual uint Id { get; set; }

    [Column("MapId", TypeName="int")]
    public virtual uint MapId { get; set; }

    [Column("Difficulty", TypeName="int")]
    public virtual uint Difficulty { get; set; }

    [Column("EncounterData", TypeName="int")]
    public virtual uint EncounterData { get; set; }

    [Column("EncounterIndex", TypeName="int")]
    public virtual uint EncounterIndex { get; set; }

    [Column("EncounterName", TypeName="text")]
    [MaxLength(65535)]
    public virtual string EncounterName { get; set; }

    [Column("EncounterName2", TypeName="text")]
    [MaxLength(65535)]
    public virtual string EncounterName2 { get; set; }

    [Column("EncounterName3", TypeName="text")]
    [MaxLength(65535)]
    public virtual string EncounterName3 { get; set; }

    [Column("EncounterName4", TypeName="text")]
    [MaxLength(65535)]
    public virtual string EncounterName4 { get; set; }

    [Column("EncounterName5", TypeName="text")]
    [MaxLength(65535)]
    public virtual string EncounterName5 { get; set; }

    [Column("EncounterName6", TypeName="text")]
    [MaxLength(65535)]
    public virtual string EncounterName6 { get; set; }

    [Column("EncounterName7", TypeName="text")]
    [MaxLength(65535)]
    public virtual string EncounterName7 { get; set; }

    [Column("EncounterName8", TypeName="text")]
    [MaxLength(65535)]
    public virtual string EncounterName8 { get; set; }

    [Column("EncounterName9", TypeName="text")]
    [MaxLength(65535)]
    public virtual string EncounterName9 { get; set; }

    [Column("EncounterName10", TypeName="text")]
    [MaxLength(65535)]
    public virtual string EncounterName10 { get; set; }

    [Column("EncounterName11", TypeName="text")]
    [MaxLength(65535)]
    public virtual string EncounterName11 { get; set; }

    [Column("EncounterName12", TypeName="text")]
    [MaxLength(65535)]
    public virtual string EncounterName12 { get; set; }

    [Column("EncounterName13", TypeName="text")]
    [MaxLength(65535)]
    public virtual string EncounterName13 { get; set; }

    [Column("EncounterName14", TypeName="text")]
    [MaxLength(65535)]
    public virtual string EncounterName14 { get; set; }

    [Column("EncounterName15", TypeName="text")]
    [MaxLength(65535)]
    public virtual string EncounterName15 { get; set; }

    [Column("EncounterName16", TypeName="text")]
    [MaxLength(65535)]
    public virtual string EncounterName16 { get; set; }

    [Column("NameLangFlags", TypeName="int")]
    public virtual uint NameLangFlags { get; set; }

    [Column("SpellIconID", TypeName="int")]
    public virtual uint SpellIconId { get; set; }

}