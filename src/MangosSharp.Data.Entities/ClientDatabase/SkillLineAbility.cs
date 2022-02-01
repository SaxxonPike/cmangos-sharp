namespace MangosSharp.Data.Entities.ClientDatabase;

[DbcTable("SkillLineAbility")]
public sealed class SkillLineAbility
{
    [System.ComponentModel.DataAnnotations.Key] [DbcField(0)]
    public int Id { get; set; }
    
    [DbcField(1)]
    public int SkillId { get; set; }
    
    [DbcField(2)]
    public int SpellId { get; set; }
    
    [DbcField(3)]
    public int RaceMask { get; set; }
    
    [DbcField(4)]
    public int ClassMask { get; set; }
    
    [DbcField(5)]
    public int Unknown5 { get; set; }
    
    [DbcField(6)]
    public int Unknown6 { get; set; }
    
    [DbcField(7)]
    public int RequiredSkillValue { get; set; }
    
    [DbcField(8)]
    public int ForwardSpellId { get; set; }
    
    [DbcField(9)]
    public int LearnOnGetSkill { get; set; }
    
    [DbcField(10)]
    public int MaxValue { get; set; }
    
    [DbcField(11)]
    public int MinValue { get; set; }
    
    [DbcField(12)]
    public int Unknown12 { get; set; }
    
    [DbcField(13)]
    public int Unknown13 { get; set; }
    
    [DbcField(14)]
    public int RequiredTrainingPoints { get; set; }
}