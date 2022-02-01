namespace MangosSharp.Data.Entities.ClientDatabase;

[DbcTable("CreatureType")]
public sealed class CreatureType
{
    [System.ComponentModel.DataAnnotations.Key] [DbcField(0)]
    public int Id { get; set; }
    
    [DbcField(1, 8)]
    public string[] Names { get; set; }
    
    [DbcField(9)]
    public int Unknown9 { get; set; }
    
    [DbcField(10)]
    public int Flags { get; set; }
}