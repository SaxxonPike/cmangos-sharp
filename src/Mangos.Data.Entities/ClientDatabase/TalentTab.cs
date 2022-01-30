namespace Mangos.Data.Entities.ClientDatabase;

[DbcTable("TalentTab")]
public sealed class TalentTab
{
    [System.ComponentModel.DataAnnotations.Key] [DbcField(0)]
    public int Id { get; set; }
    
    [DbcField(1, 8)]
    public string[] Names { get; set; }
    
    [DbcField(9)]
    public int Unknown9 { get; set; }
    
    [DbcField(10)]
    public int SpellIconId { get; set; }
    
    [DbcField(11)]
    public int RaceMask { get; set; }
    
    [DbcField(12)]
    public int ClassMask { get; set; }
    
    [DbcField(13)]
    public int TabPage { get; set; }
    
    [DbcField(14)]
    public string InternalName { get; set; }
}