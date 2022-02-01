namespace MangosSharp.Data.Entities.ClientDatabase;

[DbcTable("ItemDisplayInfo")]
public sealed class ItemDisplayInfo
{
    [System.ComponentModel.DataAnnotations.Key] [DbcField(0)]
    public int Id { get; set; }
    
    [DbcField(1)]
    public string Model0Name { get; set; }
    
    [DbcField(2)]
    public string Model1Name { get; set; }
    
    [DbcField(3)]
    public string Model0Texture { get; set; }
    
    [DbcField(4)]
    public string Model1Texture { get; set; }
    
    [DbcField(5)]
    public string Icon0 { get; set; }
    
    [DbcField(6)]
    public string Icon1 { get; set; }
    
    [DbcField(7)]
    public int GeosetGroup0 { get; set; }
    
    [DbcField(8)]
    public int GeosetGroup1 { get; set; }
    
    [DbcField(9)]
    public int GeosetGroup2 { get; set; }
    
    [DbcField(10)]
    public int SpellVisual { get; set; }
    
    [DbcField(11)]
    public int GroupSoundIndex { get; set; }
    
    [DbcField(12)]
    public int HelmetGeosetVis0 { get; set; }
    
    [DbcField(13)]
    public int HelmetGeosetVis1 { get; set; }
    
    [DbcField(14)]
    public string Texture0 { get; set; }
    
    [DbcField(15)]
    public string Texture1 { get; set; }
    
    [DbcField(16)]
    public string Texture2 { get; set; }
    
    [DbcField(17)]
    public string Texture3 { get; set; }
    
    [DbcField(18)]
    public string Texture4 { get; set; }
    
    [DbcField(19)]
    public string Texture5 { get; set; }
    
    [DbcField(20)]
    public string Texture6 { get; set; }
    
    [DbcField(21)]
    public string Texture7 { get; set; }
    
    [DbcField(22)]
    public int ItemVisual { get; set; }
}