namespace Mangos.Data.Entities.ClientDatabase;

[DbcTable("WMOAreaTable")]
public sealed class WmoArea
{
    [System.ComponentModel.DataAnnotations.Key] [DbcField(0)] public int Id { get; set; }

    [DbcField(1)] public int RootId { get; set; }

    [DbcField(2)] public int AdtId { get; set; }

    [DbcField(3)] public int GroupId { get; set; }

    [DbcField(4)] public int SoundProviderPreferences { get; set; }

    [DbcField(5)] public int SoundProviderPreferencesUnderwater { get; set; }

    [DbcField(6)] public int SoundAmbience { get; set; }

    [DbcField(7)] public int ZoneMusic { get; set; }

    [DbcField(8)] public int ZoneIntroMusicTable { get; set; }

    [DbcField(9)] public int Flags { get; set; }

    [DbcField(10)] public int AreaTable { get; set; }

    [DbcField(11, 8)] public string[] Names { get; set; }
    
    [DbcField(19)] public int Unknown19 { get; set; }
}