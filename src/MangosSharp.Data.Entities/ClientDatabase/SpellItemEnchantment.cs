namespace MangosSharp.Data.Entities.ClientDatabase;

[DbcTable("SpellItemEnchantment")]
public sealed class SpellItemEnchantment
{
    [System.ComponentModel.DataAnnotations.Key] [DbcField(0)]
    public int Id { get; set; }
    
    [DbcField(1, 3)]
    public int[] Types { get; set; }
    
    [DbcField(4, 3)]
    public int[] Amounts { get; set; }
    
    [DbcField(7, 3)]
    public int[] Amounts2 { get; set; }
    
    [DbcField(10, 3)]
    public int[] SpellIds { get; set; }
    
    [DbcField(13, 8)]
    public string[] Descriptions { get; set; }
    
    [DbcField(21)]
    public int Unknown21 { get; set; }
    
    [DbcField(22)]
    public int AuraId { get; set; }
    
    [DbcField(23)]
    public int Slot { get; set; }
}