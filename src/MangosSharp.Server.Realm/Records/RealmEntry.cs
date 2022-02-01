using MangosSharp.Server.Realm.Enums;

namespace MangosSharp.Server.Realm.Records;

public sealed class RealmEntry
{
    public uint Id { get; set; }
    public int Icon { get; set; }
    public RealmFlag Flags { get; set; }
    public int TimeZone { get; set; }
    public int AllowedSecurityLevel { get; set; }
    public float PopulationLevel { get; set; }
    public int[] Builds { get; set; }
    public string Name { get; set; }
    public string Endpoint { get; set; }
}