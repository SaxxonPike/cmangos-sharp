namespace MangosSharp.Data.Entities.ClientDatabase;

[DbcTable("TaxiPathNode")]
public sealed class TaxiPathNode
{
    [System.ComponentModel.DataAnnotations.Key] [DbcField(0)]
    public int Id { get; set; }
    
    [DbcField(1)]
    public int PathId { get; set; }
    
    [DbcField(2)]
    public int Index { get; set; }
    
    [DbcField(3)]
    public int MapId { get; set; }
    
    [DbcField(4)]
    public float X { get; set; }
    
    [DbcField(5)]
    public float Y { get; set; }
    
    [DbcField(6)]
    public float Z { get; set; }
    
    [DbcField(7)]
    public int ActionFlags { get; set; }
    
    [DbcField(8)]
    public int Delay { get; set; }
}