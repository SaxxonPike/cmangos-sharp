namespace MangosSharp.Data.Entities.ClientDatabase;

[DbcTable("ItemClass")]
public sealed class ItemClass
{
    [System.ComponentModel.DataAnnotations.Key] [DbcField(0)]
    public int Id { get; set; }
    
    [DbcField(1)]
    public int Unknown1 { get; set; }
    
    [DbcField(2)]
    public int Unknown2 { get; set; }
    
    [DbcField(3, 8)]
    public string[] Names { get; set; }
    
    [DbcField(12)]
    public int Unknown12 { get; set; }
}