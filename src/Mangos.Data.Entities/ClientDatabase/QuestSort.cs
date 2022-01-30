namespace Mangos.Data.Entities.ClientDatabase;

[DbcTable("QuestSort")]
public sealed class QuestSort
{
    [System.ComponentModel.DataAnnotations.Key] [DbcField(0)]
    public int Id { get; set; }
    
    [DbcField(1, 8)]
    public string[] Names { get; set; }
    
    [DbcField(9)]
    public int Unknown9 { get; set; }
}