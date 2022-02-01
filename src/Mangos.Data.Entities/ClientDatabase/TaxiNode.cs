namespace Mangos.Data.Entities.ClientDatabase;

[DbcTable("TaxiNodes")]
public sealed class TaxiNode
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
    
    [DbcField(14, 2)]
    public int[] MountCreatureIds { get; set; }
}