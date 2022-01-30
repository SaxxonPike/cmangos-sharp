namespace Mangos.Data.Entities.ClientDatabase;

[DbcTable("SoundEntries")]
public sealed class SoundEntry
{
    [System.ComponentModel.DataAnnotations.Key] [DbcField(0)]
    public int Id { get; set; }
    
    [DbcField(1)]
    public int Type { get; set; }
    
    [DbcField(2)]
    public string InternalName { get; set; }
    
    [DbcField(3, 10)]
    public string FileNames { get; set; }
    
    [DbcField(13, 10)]
    public string[] Unknown13 { get; set; }
    
    [DbcField(23)]
    public string Path { get; set; }
    
    [DbcField(24)]
    public float Volume { get; set; }
    
    [DbcField(25)]
    public int Flags { get; set; }
    
    [DbcField(26)]
    public int MinDistance { get; set; }
    
    [DbcField(27)]
    public int DistanceCutoff { get; set; }
    
    [DbcField(28)]
    public int EaxDefinition { get; set; }
}