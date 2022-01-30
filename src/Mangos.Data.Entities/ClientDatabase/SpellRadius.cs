namespace Mangos.Data.Entities.ClientDatabase;

[DbcTable("SpellRadius")]
public sealed class SpellRadius
{
    [System.ComponentModel.DataAnnotations.Key] [DbcField(0)]
    public int Id { get; set; }
    
    [DbcField(1)]
    public float Radius { get; set; }
    
    [DbcField(2)]
    public float RadiusPerLevel { get; set; }
    
    [DbcField(3)]
    public float RadiusMax { get; set; }
}