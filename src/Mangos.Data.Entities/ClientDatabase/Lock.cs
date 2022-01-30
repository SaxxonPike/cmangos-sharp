namespace Mangos.Data.Entities.ClientDatabase;

[DbcTable("Lock")]
public sealed class Lock
{
    [System.ComponentModel.DataAnnotations.Key] [DbcField(0)]
    public int Id { get; set; }
    
    [DbcField(1, 4)]
    public int[] Types { get; set; }
    
    [DbcField(5, 4)]
    public int[] Indices { get; set; }
    
    [DbcField(9, 4)]
    public int[] Skills { get; set; }
    
    [DbcField(13, 4)]
    public int[] Actions { get; set; }
}