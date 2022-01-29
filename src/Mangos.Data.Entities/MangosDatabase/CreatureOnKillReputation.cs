using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("creature_onkill_reputation")]
public class CreatureOnKillReputation
{
    /* Creature Identifier */
    [Column("creature_id", TypeName="mediumint")]
    public virtual uint CreatureId { get; set; }

    [Column("RewOnKillRepFaction1", TypeName="smallint")]
    public virtual int RewOnKillRepFaction1 { get; set; }

    [Column("RewOnKillRepFaction2", TypeName="smallint")]
    public virtual int RewOnKillRepFaction2 { get; set; }

    [Column("MaxStanding1", TypeName="tinyint")]
    public virtual int MaxStanding1 { get; set; }

    [Column("IsTeamAward1", TypeName="tinyint")]
    public virtual int IsTeamAward1 { get; set; }

    [Column("RewOnKillRepValue1", TypeName="mediumint")]
    public virtual int RewOnKillRepValue1 { get; set; }

    [Column("MaxStanding2", TypeName="tinyint")]
    public virtual int MaxStanding2 { get; set; }

    [Column("IsTeamAward2", TypeName="tinyint")]
    public virtual int IsTeamAward2 { get; set; }

    [Column("RewOnKillRepValue2", TypeName="mediumint")]
    public virtual int RewOnKillRepValue2 { get; set; }

    [Column("TeamDependent", TypeName="tinyint")]
    public virtual byte TeamDependent { get; set; }

}