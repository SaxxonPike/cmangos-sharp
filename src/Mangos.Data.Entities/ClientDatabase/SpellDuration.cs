namespace Mangos.Data.Entities.ClientDatabase;

[DbcTable("SpellDuration")]
public sealed class SpellDuration
{
    [System.ComponentModel.DataAnnotations.Key] [DbcField(0)]
    public int Id { get; set; }
    
    [DbcField(1, 3)]
    public int Durations { get; set; }
}