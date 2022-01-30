namespace Mangos.Data.Entities.ClientDatabase;

[DbcTable("CreatureDisplayInfoExtra")]
public sealed class CreatureDisplayInfoExtra
{
    [System.ComponentModel.DataAnnotations.Key] [DbcField(0)]
    public int Id { get; set; }
    
    [DbcField(1)]
    public int Race { get; set; }
    
    [DbcField(2)]
    public int Gender { get; set; }
    
    [DbcField(3)]
    public int SkinColor { get; set; }
    
    [DbcField(4)]
    public int FaceType { get; set; }
    
    [DbcField(5)]
    public int HairType { get; set; }
    
    [DbcField(6)]
    public int HairStyle { get; set; }
    
    [DbcField(7)]
    public int BeardStyle { get; set; }
    
    [DbcField(8, 10)]
    public int[] Equipment { get; set; }
    
    [DbcField(18)]
    public string BakeName { get; set; }
}