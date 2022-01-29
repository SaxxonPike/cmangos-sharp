using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("instance_encounters")]
public class InstanceEncounter
{
    /* Unique entry from DungeonEncounter.dbc */
    [Column("entry", TypeName="int")]
    public virtual uint Entry { get; set; }

    [Column("creditType", TypeName="tinyint")]
    public virtual byte CreditType { get; set; }

    [Column("creditEntry", TypeName="int")]
    public virtual uint CreditEntry { get; set; }

    /* If not 0, LfgDungeon.dbc entry for the instance it is last encounter in */
    [Column("lastEncounterDungeon", TypeName="smallint")]
    public virtual uint LastEncounterDungeon { get; set; }

}