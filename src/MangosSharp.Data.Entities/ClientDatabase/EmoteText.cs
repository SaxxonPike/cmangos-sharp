namespace MangosSharp.Data.Entities.ClientDatabase;

[DbcTable("EmotesText")]
public sealed class EmoteText
{
    [System.ComponentModel.DataAnnotations.Key] [DbcField(0)]
    public int Id { get; set; }
    
    [DbcField(1)]
    public int TextId { get; set; }
}