namespace MangosSharp.Data.Entities.ClientDatabase;

[DbcTable("ItemRandomProperties")]
public sealed class ItemRandomProperty
{
    [System.ComponentModel.DataAnnotations.Key] [DbcField(0)]
    public int Id { get; set; }
    
    [DbcField(1)]
    public string InternalName { get; set; }
    
    [DbcField(2, 3)]
    public int[] EnchantIds { get; set; }
    
    [DbcField(5)]
    public int Unknown5 { get; set; }
    
    [DbcField(6)]
    public int Unknown6 { get; set; }
    
    [DbcField(7, 8)]
    public string[] Suffixes { get; set; }
    
    [DbcField(15)]
    public int Unknown15 { get; set; }
}