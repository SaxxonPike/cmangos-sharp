namespace MangosSharp.Data.Entities.ClientDatabase;

[DbcTable("SpellCastTimes")]
public sealed class SpellCastTime
{
    [System.ComponentModel.DataAnnotations.Key] [DbcField(0)]
    public int Id { get; set; }
    
    [DbcField(1)]
    public int CastTime { get; set; }
    
    [DbcField(2)]
    public int CastTimePerLevel { get; set; }
    
    [DbcField(3)]
    public int MinCastTime { get; set; }
}