namespace Mangos.Data.Entities.ClientDatabase;

[DbcTable("SpellRange")]
public sealed class SpellRange
{
    [System.ComponentModel.DataAnnotations.Key] [DbcField(0)]
    public int Id { get; set; }
    
    [DbcField(1)]
    public float MinRange { get; set; }
    
    [DbcField(2)]
    public float MaxRange { get; set; }
    
    [DbcField(3)]
    public int Flags { get; set; }
    
    [DbcField(4, 8)]
    public string[] Names { get; set; }
    
    [DbcField(12)]
    public int Unknown12 { get; set; }
    
    [DbcField(13, 8)]
    public string[] ShortNames { get; set; }
    
    [DbcField(21)]
    public int Unknown21 { get; set; }
}