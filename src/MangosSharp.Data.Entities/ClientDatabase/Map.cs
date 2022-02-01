namespace MangosSharp.Data.Entities.ClientDatabase;

[DbcTable("Map")]
public sealed class Map
{
    [System.ComponentModel.DataAnnotations.Key] [DbcField(0)] public int Id { get; set; }
    [DbcField(1)] public string InternalName { get; set; }
    [DbcField(2)] public int InstanceType { get; set; }
    [DbcField(3)] public bool IsBattleground { get; set; }
    [DbcField(4, 8)] public string[] Names { get; set; }
    [DbcField(12)] public int Unknown12 { get; set; }
    [DbcField(13)] public int Unknown13 { get; set; }
    [DbcField(14)] public int Unknown14 { get; set; }
    [DbcField(15)] public int Unknown15 { get; set; }
    [DbcField(16)] public int Unknown16 { get; set; }
    [DbcField(17)] public int Unknown17 { get; set; }
    [DbcField(18)] public int Unknown18 { get; set; }
    [DbcField(19)] public int LinkedZone { get; set; }
    [DbcField(20, 8)] public string[] HordeIntros { get; set; }
    [DbcField(28)] public int Unknown28 { get; set; }
    [DbcField(29, 8)] public string[] AllianceIntros { get; set; }
    [DbcField(37)] public int Unknown37 { get; set; }
    [DbcField(38)] public int LoadingScreenId { get; set; }
    [DbcField(39)] public int Unknown39 { get; set; }
    [DbcField(40)] public int Unknown40 { get; set; }
    [DbcField(41)] public float BattlefieldMapIconScale { get; set; }
}