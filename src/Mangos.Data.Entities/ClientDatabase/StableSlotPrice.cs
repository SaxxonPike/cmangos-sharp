namespace Mangos.Data.Entities.ClientDatabase;

[DbcTable("StableSlotPrices")]
public sealed class StableSlotPrice
{
    [System.ComponentModel.DataAnnotations.Key] [DbcField(0)]
    public int Slot { get; set; }
    
    [DbcField(1)]
    public int Cost { get; set; }
}