namespace Mangos.Data.Entities.ClientDatabase;

[DbcTable("LiquidType")]
public sealed class LiquidType
{
    [System.ComponentModel.DataAnnotations.Key] [DbcField(0)]
    public int Id { get; set; }
    
    [DbcField(1)]
    public int LiquidId { get; set; }
    
    [DbcField(2)]
    public int Type { get; set; }
    
    [DbcField(3)]
    public int SpellId { get; set; }
}