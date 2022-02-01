using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("reputation_spillover_template")]
public class ReputationSpilloverTemplate
{
    /* faction entry */
    [Column("faction", TypeName="smallint")]
    public virtual ushort Faction { get; set; }

    /* faction to give spillover for */
    [Column("faction1", TypeName="smallint")]
    public virtual ushort Faction1 { get; set; }

    [Column("faction2", TypeName="smallint")]
    public virtual ushort Faction2 { get; set; }

    [Column("faction3", TypeName="smallint")]
    public virtual ushort Faction3 { get; set; }

    [Column("faction4", TypeName="smallint")]
    public virtual ushort Faction4 { get; set; }

    /* max rank, above this will not give any spillover */
    [Column("rank_1", TypeName="tinyint")]
    public virtual byte Rank1 { get; set; }

    [Column("rank_2", TypeName="tinyint")]
    public virtual byte Rank2 { get; set; }

    [Column("rank_3", TypeName="tinyint")]
    public virtual byte Rank3 { get; set; }

    [Column("rank_4", TypeName="tinyint")]
    public virtual byte Rank4 { get; set; }

    /* the given rep points * rate */
    [Column("rate_1", TypeName="float")]
    public virtual float Rate1 { get; set; }

    [Column("rate_2", TypeName="float")]
    public virtual float Rate2 { get; set; }

    [Column("rate_3", TypeName="float")]
    public virtual float Rate3 { get; set; }

    [Column("rate_4", TypeName="float")]
    public virtual float Rate4 { get; set; }

}