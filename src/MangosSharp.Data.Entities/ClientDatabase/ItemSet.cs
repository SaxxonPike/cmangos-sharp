namespace MangosSharp.Data.Entities.ClientDatabase;

[DbcTable("ItemSet")]
public sealed class ItemSet
{
    [System.ComponentModel.DataAnnotations.Key] [DbcField(0)]
    public int Id { get; set; }
    
    [DbcField(1, 8)]
    public string[] Names { get; set; }
    
    [DbcField(9)]
    public int Unknown9 { get; set; }
    
    [DbcField(10, 17)]
    public int[] ItemIds { get; set; }
    
    [DbcField(27, 8)]
    public int[] SpellIds { get; set; }
    
    [DbcField(35, 8)]
    public int[] ItemsToTrigger { get; set; }
    
    [DbcField(43)]
    public int RequiredSkillId { get; set; }
    
    [DbcField(44)]
    public int RequiredSkillValue { get; set; }
}