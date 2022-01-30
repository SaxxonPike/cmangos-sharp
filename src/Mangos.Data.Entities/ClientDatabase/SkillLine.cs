namespace Mangos.Data.Entities.ClientDatabase;

[DbcTable("SkillLine")]
public sealed class SkillLine
{
    [System.ComponentModel.DataAnnotations.Key] [DbcField(0)]
    public int Id { get; set; }
    
    [DbcField(1)]
    public int CategoryId { get; set; }
    
    [DbcField(2)]
    public int SkillCostId { get; set; }
    
    [DbcField(3, 8)]
    public string[] Names { get; set; }
    
    [DbcField(11)]
    public int Unknown11 { get; set; }
    
    [DbcField(12)]
    public string[] Descriptions { get; set; }
    
    [DbcField(20)]
    public int Unknown20 { get; set; }
    
    [DbcField(21)]
    public int Icon { get; set; }
}