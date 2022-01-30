namespace Mangos.Data.Entities.ClientDatabase;

[DbcTable("WorldMapArea")]
public sealed class WorldMapArea
{
    [System.ComponentModel.DataAnnotations.Key] [DbcField(0)]
    public int Id { get; set; }
    
    [DbcField(1)]
    public int MapId { get; set; }
    
    [DbcField(2)]
    public int AreaId { get; set; }
    
    [DbcField(3)]
    public string InternalName { get; set; }
    
    [DbcField(4)]
    public float Y1 { get; set; }
    
    [DbcField(5)]
    public float Y2 { get; set; }
    
    [DbcField(6)]
    public float X1 { get; set; }
    
    [DbcField(7)]
    public float X2 { get; set; }
}