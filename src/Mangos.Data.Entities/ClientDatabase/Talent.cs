namespace Mangos.Data.Entities.ClientDatabase;

[DbcTable("Talent")]
public sealed class Talent
{
    [System.ComponentModel.DataAnnotations.Key] [DbcField(0)]
    public int Id { get; set; }
    
    [DbcField(1)]
    public int Tab { get; set; }
    
    [DbcField(2)]
    public int Row { get; set; }
    
    [DbcField(3)]
    public int Column { get; set; }
    
    [DbcField(4, 5)]
    public int[] RankIds { get; set; }
    
    [DbcField(9, 4)]
    public int[] Unknown9 { get; set; }
    
    [DbcField(13)]
    public int DependsOn { get; set; }
    
    [DbcField(14, 2)]
    public int[] Unknown14 { get; set; }
    
    [DbcField(16)]
    public int DependsOnRank { get; set; }
    
    [DbcField(17, 2)]
    public int[] Unknown17 { get; set; }
    
    [DbcField(19)]
    public int Flags { get; set; }
    
    [DbcField(20)]
    public int DependsOnSpell { get; set; }
}