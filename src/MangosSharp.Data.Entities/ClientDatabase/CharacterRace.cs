namespace MangosSharp.Data.Entities.ClientDatabase;

/* The character races table contains definitions for available races, including their settings for sound, display,
   data files, etc. */

[DbcTable("ChrRaces")]
public sealed class CharacterRace
{
    [System.ComponentModel.DataAnnotations.Key] [DbcField(0)] public int Id { get; set; }
    [DbcField(1)] public int Flags { get; set; }
    [DbcField(2)] public int Faction { get; set; }
    [DbcField(3)] public int ExplorationSound { get; set; }
    [DbcField(4)] public int MaleDisplayId { get; set; }
    [DbcField(5)] public int FemaleDisplayId { get; set; }
    [DbcField(6)] public string ClientPrefix { get; set; }
    [DbcField(7)] public float SpeedModifier { get; set; }
    [DbcField(8)] public int BaseLanguage { get; set; }
    [DbcField(9)] public int CreatureType { get; set; }
    [DbcField(10)] public int LoginEffect { get; set; }
    [DbcField(11)] public int Unknown11 { get; set; }
    [DbcField(12)] public int ResSicknessSpellId { get; set; }
    [DbcField(13)] public int SplashSoundEntry { get; set; }
    [DbcField(14)] public int StartingTaxiMask { get; set; }
    [DbcField(15)] public string ClientFileString { get; set; }
    [DbcField(16)] public int CinematicSequence { get; set; }
    [DbcField(17, 8)] public string[] Names { get; set; }
    [DbcField(25)] public int Unknown25 { get; set; }
    [DbcField(26)] public string Customization1 { get; set; }
    [DbcField(27)] public string Customization2 { get; set; }
    [DbcField(28)] public string Customization3 { get; set; }
}