using System;
using MangosSharp.Core;

namespace MangosSharp.Server.Core.Views;

public interface IItemObjectView : IObjectView
{
    ObjectGuid Contained { get; set; }
    ObjectGuid Creator { get; set; }
    ObjectGuid GiftCreator { get; set; }
    int StackCount { get; set; }
    int Duration { get; set; }
    Span<int> SpellCharges { get; }
    int ItemFlags { get; set; }
    Span<int> Enchantments { get; }
    int PropertySeed { get; set; }
    int RandomPropertiesId { get; set; }
    int TextId { get; set; }
    int Durability { get; set; }
    int MaxDurability { get; set; }
}