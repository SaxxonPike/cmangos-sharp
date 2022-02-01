namespace MangosSharp.Data.Entities.ClientDatabase;

[DbcTable("ChrClasses")]
public sealed class CharacterClass
{
    [System.ComponentModel.DataAnnotations.Key] [DbcField(0)] public int Id { get; set; }
    [DbcField(1)] public int Unknown1 { get; set; }
    [DbcField(2)] public int Unknown2 { get; set; }
    [DbcField(3)] public int PowerType { get; set; }
    [DbcField(4)] public string PetNameToken { get; set; }
    [DbcField(5, 8)] public string[] Names { get; set; }
    [DbcField(13)] public string Unknown13 { get; set; }
    [DbcField(14)] public string FileName { get; set; }
    [DbcField(15)] public int SpellFamily { get; set; }
    [DbcField(16)] public int Flags { get; set; }
}