namespace MangosSharp.Data.Entities.ClientDatabase;

[DbcTable("CreatureSpellData")]
public sealed class CreatureSpellData
{
    [System.ComponentModel.DataAnnotations.Key] [DbcField(0)]
    public int Id { get; set; }
    
    [DbcField(1, 4)]
    public int[] SpellIds { get; set; }
    
    [DbcField(5, 4)]
    public int[] Availability { get; set; }
}