namespace MangosSharp.Data.Entities.ClientDatabase;

[DbcTable("DurabilityQuality")]
public sealed class DurabilityQuality
{
    [System.ComponentModel.DataAnnotations.Key] [DbcField(0)]
    public int Id { get; set; }
    
    [DbcField(1)]
    public float Modifier { get; set; }
}