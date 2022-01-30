namespace Mangos.Data.Entities.ClientDatabase;

[DbcTable("FactionTemplate")]
public sealed class FactionTemplate
{
    [System.ComponentModel.DataAnnotations.Key] [DbcField(0)]
    public int Id { get; set; }
    
    [DbcField(1)]
    public int FactionId { get; set; }
    
    [DbcField(2)]
    public int FactionFlags { get; set; }
    
    [DbcField(3)]
    public int OurMask { get; set; }
    
    [DbcField(4)]
    public int FriendlyMask { get; set; }
    
    [DbcField(5)]
    public int HostileMask { get; set; }
    
    [DbcField(6, 4)]
    public int[] EnemyFactions { get; set; }
    
    [DbcField(10, 4)]
    public int[] FriendFactions { get; set; }
}
