namespace MangosSharp.Data.Entities.ClientDatabase;

[DbcTable("CreatureFamily")]
public sealed class CreatureFamily
{
    [System.ComponentModel.DataAnnotations.Key] [DbcField(0)]
    public int Id { get; set; }
    
    [DbcField(1)]
    public float MinScale { get; set; }
    
    [DbcField(2)]
    public int MinScaleLevel { get; set; }
    
    [DbcField(3)]
    public float MaxScale { get; set; }
    
    [DbcField(4)]
    public int MaxScaleLevel { get; set; }
    
    [DbcField(5, 2)]
    public int[] SkillLineIds { get; set; }
    
    [DbcField(7)]
    public int PetFoodMask { get; set; }
    
    [DbcField(8)]
    public string Name { get; set; }
}