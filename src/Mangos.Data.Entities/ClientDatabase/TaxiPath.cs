namespace Mangos.Data.Entities.ClientDatabase;

[DbcTable("TaxiPath")]
public sealed class TaxiPath
{
    [System.ComponentModel.DataAnnotations.Key] [DbcField(0)]
    public int Id { get; set; }
    
    [DbcField(1)]
    public int From { get; set; }
    
    [DbcField(2)]
    public int To { get; set; }
    
    [DbcField(3)]
    public int Price { get; set; }
}