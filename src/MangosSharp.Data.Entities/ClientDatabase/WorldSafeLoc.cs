namespace MangosSharp.Data.Entities.ClientDatabase;

[DbcTable("WorldSafeLocs")]
public sealed class WorldSafeLoc
{
    [System.ComponentModel.DataAnnotations.Key] [DbcField(0)]
    public int Id { get; set; }
    
    [DbcField(1)]
    public int MapId { get; set; }
    
    [DbcField(2)]
    public float X { get; set; }
    
    [DbcField(3)]
    public float Y { get; set; }
    
    [DbcField(4)]
    public float Z { get; set; }
    
    [DbcField(5, 8)]
    public string[] Names { get; set; }
    
    [DbcField(13)]
    public int Unknown13 { get; set; }
}