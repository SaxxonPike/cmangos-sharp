namespace MangosSharp.Data.Entities.ClientDatabase;

[DbcTable("CinematicSequences")]
public sealed class CinematicSequence
{
    [System.ComponentModel.DataAnnotations.Key] [DbcField(0)]
    public int Id { get; set; }
    
    [DbcField(1)]
    public int SoundId { get; set; }
    
    [DbcField(2, 8)]
    public int Cameras { get; set; }
}