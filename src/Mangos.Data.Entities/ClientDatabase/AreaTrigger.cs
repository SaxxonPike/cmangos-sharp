namespace Mangos.Data.Entities.ClientDatabase;

[DbcTable("AreaTrigger")]
public sealed class AreaTrigger
{
    [System.ComponentModel.DataAnnotations.Key] [DbcField(0)] public int Id { get; set; }
    [DbcField(1)] public int Map { get; set; }
    [DbcField(2)] public float LocationX { get; set; }
    [DbcField(3)] public float LocationY { get; set; }
    [DbcField(4)] public float LocationZ { get; set; }
    [DbcField(5)] public float Radius { get; set; }
    [DbcField(6)] public float SizeX { get; set; }
    [DbcField(7)] public float SizeY { get; set; }
    [DbcField(8)] public float SizeZ { get; set; }
    [DbcField(9)] public float Orientation { get; set; }
}