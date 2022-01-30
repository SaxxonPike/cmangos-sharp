namespace Mangos.Data.Entities.ClientDatabase;

[DbcTable("Emotes")]
public sealed class Emote
{
    [System.ComponentModel.DataAnnotations.Key] [DbcField(0)] public int Id { get; set; }

    [DbcField(1)] public string Name { get; set; }

    [DbcField(2)] public int AnimationId { get; set; }

    [DbcField(3)] public int Flags { get; set; }

    [DbcField(4)] public int Type { get; set; }

    [DbcField(5)] public int StandState { get; set; }

    [DbcField(6)] public int EventSoundId { get; set; }
}