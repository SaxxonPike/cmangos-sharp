namespace Mangos.Data.Entities.ClientDatabase;

[DbcTable("GameObjectDisplayInfo")]
public sealed class GameObjectDisplayInfo
{
    [System.ComponentModel.DataAnnotations.Key] [DbcField(0)]
    public int Id { get; set; }
    
    [DbcField(1)]
    public string ModelName { get; set; }
    
    [DbcField(2, 10)]
    public int[] SoundIds { get; set; }
}