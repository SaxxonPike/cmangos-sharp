namespace Mangos.Data.Entities.ClientDatabase;

[DbcTable("AreaTable")]
public sealed class Area
{
    [System.ComponentModel.DataAnnotations.Key] [DbcField(0)] public int Id { get; set; }
    [DbcField(1)] public int MapId { get; set; }
    [DbcField(2)] public int ZoneId { get; set; }
    [DbcField(3)] public int ExploreFlag { get; set; }
    [DbcField(4)] public int Flags { get; set; }
    [DbcField(5)] public int SoundPreferences { get; set; }
    [DbcField(6)] public int SoundPreferencesUnderwater { get; set; }
    [DbcField(7)] public int SoundAmbience { get; set; }
    [DbcField(8)] public int ZoneMusic { get; set; }
    [DbcField(9)] public int ZoneIntroMusicTable { get; set; }
    [DbcField(10)] public int ExplorationLevel { get; set; }
    [DbcField(11, 8)] public string[] AreaNames { get; set; }
    [DbcField(19)] public int Unknown19 { get; set; }
    [DbcField(20)] public int FactionGroup { get; set; }
    [DbcField(21)] public int Unknown21 { get; set; }
    [DbcField(22)] public int Unknown22 { get; set; }
    [DbcField(23)] public int Unknown23 { get; set; }
    [DbcField(24)] public int LiquidType { get; set; }
}