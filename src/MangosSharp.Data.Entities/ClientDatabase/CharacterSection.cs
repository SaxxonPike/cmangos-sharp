using System.ComponentModel.DataAnnotations;

namespace MangosSharp.Data.Entities.ClientDatabase;

[DbcTable("CharSections")]
public sealed class CharacterSection
{
    [Key]
    [DbcField(0)]
    public int Id { get; set; }
    
    [DbcField(1)]
    public int Race { get; set; }
    
    [DbcField(2)]
    public int Gender { get; set; }
    
    [DbcField(3)]
    public int SectionType { get; set; }
    
    [DbcField(4)]
    public int VariationIndex { get; set; }
    
    [DbcField(5)]
    public int ColorIndex { get; set; }
    
    [DbcField(6, 3)]
    public string[] TextureNames { get; set; }
    
    [DbcField(9)]
    public int Flags { get; set; }
}