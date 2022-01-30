namespace Mangos.Data.Entities.ClientDatabase;

[DbcTable("BankBagSlotPrices")]
public sealed class BankBagSlotPrice
{
    [System.ComponentModel.DataAnnotations.Key] [DbcField(0)] public int Id { get; set; }
    [DbcField(1)] public int Cost { get; set; }
}