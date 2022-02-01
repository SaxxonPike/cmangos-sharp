namespace MangosSharp.Data.Entities.ClientDatabase;

[DbcTable("AuctionHouse")]
public sealed class AuctionHouse
{
    [System.ComponentModel.DataAnnotations.Key] [DbcField(0)]
    public int Id { get; set; }
    [DbcField(1)]
    public int Faction { get; set; }
    [DbcField(2)]
    public int DepositPercent { get; set; }
    [DbcField(3)]
    public int CutPercent { get; set; }
    [DbcField(4, 8)]
    public string[] Names { get; set; }
    [DbcField(12)]
    public int Unknown12 { get; set; }
}