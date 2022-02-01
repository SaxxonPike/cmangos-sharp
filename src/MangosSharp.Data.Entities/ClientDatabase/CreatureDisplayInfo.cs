namespace MangosSharp.Data.Entities.ClientDatabase;

[DbcTable("CreatureDisplayInfo")]
public sealed class CreatureDisplayInfo
{
    [System.ComponentModel.DataAnnotations.Key] [DbcField(0)]
    public int Id { get; set; }
    
    [DbcField(1)]
    public int ModelId { get; set; }
    
    [DbcField(2)]
    public int SoundId { get; set; }
    
    [DbcField(3)]
    public int ExtendedDisplayInfoId { get; set; }
    
    [DbcField(4)]
    public float CreatureModelScale { get; set; }
    
    [DbcField(5)]
    public float CreatureModelAlpha { get; set; }
    
    [DbcField(6, 3)]
    public string[] TextureVariations { get; set; }
    
    [DbcField(9)]
    public int PortraitTexture { get; set; }
    
    [DbcField(10)]
    public int BloodId { get; set; }
    
    [DbcField(11)]
    public int NpcSoundId { get; set; }
}