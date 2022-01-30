namespace Mangos.Data.Entities.ClientDatabase;

[DbcTable("ChatChannels")]
public sealed class ChatChannel
{
    [System.ComponentModel.DataAnnotations.Key] [DbcField(0)] public int Id { get; set; }

    [DbcField(1)] public int Flags { get; set; }

    [DbcField(2)] public int FactionGroup { get; set; }

    [DbcField(3, 8)] public string[] Names { get; set; }

    [DbcField(11)] public int Unknown11 { get; set; }

    [DbcField(12, 8)] public string[] ShortNames { get; set; }

    [DbcField(20)] public int Unknown20 { get; set; }
}