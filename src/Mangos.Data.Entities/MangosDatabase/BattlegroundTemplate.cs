using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("battleground_template")]
public class BattlegroundTemplate
{
    [Column("id", TypeName="mediumint")]
    public virtual uint Id { get; set; }

    [Column("MinPlayersPerTeam", TypeName="smallint")]
    public virtual uint MinPlayersPerTeam { get; set; }

    [Column("MaxPlayersPerTeam", TypeName="smallint")]
    public virtual uint MaxPlayersPerTeam { get; set; }

    [Column("MinLvl", TypeName="tinyint")]
    public virtual byte MinLvl { get; set; }

    [Column("MaxLvl", TypeName="tinyint")]
    public virtual byte MaxLvl { get; set; }

    [Column("AllianceStartLoc", TypeName="mediumint")]
    public virtual uint AllianceStartLoc { get; set; }

    [Column("HordeStartLoc", TypeName="mediumint")]
    public virtual uint HordeStartLoc { get; set; }

    [Column("StartMaxDist", TypeName="float")]
    public virtual float StartMaxDist { get; set; }

}