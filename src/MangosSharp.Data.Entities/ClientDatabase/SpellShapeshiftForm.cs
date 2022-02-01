namespace MangosSharp.Data.Entities.ClientDatabase;

[DbcTable("SpellShapeshiftForm")]
public sealed class SpellShapeshiftForm
{
    [System.ComponentModel.DataAnnotations.Key] [DbcField(0)]
    public int Id { get; set; }
    
    [DbcField(1)]
    public int ButtonPosition { get; set; }
    
    [DbcField(2, 8)]
    public string[] Names { get; set; }
    
    [DbcField(10)]
    public int Unknown10 { get; set; }
    
    [DbcField(11)]
    public int Flags { get; set; }
    
    [DbcField(12)]
    public int CreatureType { get; set; }
    
    [DbcField(13)]
    public int AttackIconId { get; set; }
}