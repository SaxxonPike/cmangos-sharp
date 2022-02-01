using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.CharacterDatabase;

[Table("pvpstats_battlegrounds")]
public class PvpstatsBattlegrounds
{
    [Column("bracket_id", TypeName="tinyint")]
    public virtual byte BracketId { get; set; }

    [Column("date", TypeName="datetime")]
    public virtual DateTimeOffset Date { get; set; }

    [Column("id", TypeName="bigint")]
    public virtual ulong Id { get; set; }

    [Column("type", TypeName="tinyint")]
    public virtual byte Type { get; set; }

    [Column("winner_team", TypeName="tinyint")]
    public virtual sbyte WinnerTeam { get; set; }

}