namespace Mangos.Data.Entities.ClientDatabase;

[DbcTable("SkillRaceClassInfo")]
public sealed class SkillRaceClass
{
    [System.ComponentModel.DataAnnotations.Key] [DbcField(0)]
    public int Id { get; set; }
    
    [DbcField(1)]
    public int SkillId { get; set; }
    
    [DbcField(2)]
    public int RaceMask { get; set; }
    
    [DbcField(3)]
    public int ClassMask { get; set; }
    
    [DbcField(4)]
    public int Flags { get; set; }
    
    [DbcField(5)]
    public int RequiredLevel { get; set; }
    
    [DbcField(6)]
    public int SkillTierId { get; set; }
    
    [DbcField(7)]
    public int SkillCostId { get; set; }
}