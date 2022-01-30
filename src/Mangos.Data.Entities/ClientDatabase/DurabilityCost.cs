namespace Mangos.Data.Entities.ClientDatabase;

[DbcTable("DurabilityCosts")]
public sealed class DurabilityCost
{
    [System.ComponentModel.DataAnnotations.Key] [DbcField(0)]
    public int Level { get; set; }
    
    [DbcField(1, 29)]
    public int[] Multipliers { get; set; }
}