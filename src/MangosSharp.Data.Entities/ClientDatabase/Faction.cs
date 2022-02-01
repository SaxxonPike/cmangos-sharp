namespace MangosSharp.Data.Entities.ClientDatabase;

[DbcTable("Faction")]
public sealed class Faction
{
    [System.ComponentModel.DataAnnotations.Key] [DbcField(0)]
    public int Id { get; set; }
    
    [DbcField(1)]
    public int ReputationIndex { get; set; }
    
    [DbcField(2, 4)]
    public int[] ReputationRaceMasks { get; set; }
    
    [DbcField(6, 4)]
    public int[] ReputationClassMasks { get; set; }
    
    [DbcField(10, 4)]
    public int[] ReputationBase { get; set; }
    
    [DbcField(14, 4)]
    public int[] ReputationFlags { get; set; }
    
    [DbcField(18)]
    public int ParentFactionId { get; set; }
    
    [DbcField(19, 8)]
    public string[] Names { get; set; }
    
    [DbcField(27)]
    public int Unknown27 { get; set; }
    
    [DbcField(28, 8)]
    public string[] Descriptions { get; set; }
    
    [DbcField(36)]
    public int Unknown36 { get; set; }
}