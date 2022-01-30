namespace Mangos.Data.Entities.ClientDatabase;

[DbcTable("CharStartOutfit")]
public sealed class CharacterStartingOutfit
{
    [System.ComponentModel.DataAnnotations.Key] [DbcField(0)] public int Id { get; set; }

    [DbcField(1, offset: 0)] public byte Race { get; set; }

    [DbcField(1, offset: 1)] public byte Class { get; set; }

    [DbcField(1, offset: 2)] public byte Gender { get; set; }

    [DbcField(1, offset: 3)] public byte OutfitId { get; set; }

    [DbcField(2, 12)] public int[] ItemIds { get; set; }

    [DbcField(14, 12)] public int[] DisplayIds { get; set; }
    
    [DbcField(26, 12)] public int[] InventorySlots { get; set; }
    
    [DbcField(38)] public int Unknown38 { get; set; }
    
    [DbcField(39)] public int Unknown39 { get; set; }
    
    [DbcField(40)] public int Unknown40 { get; set; }
}