using System;
using MangosSharp.Core;

namespace MangosSharp.Server.Core.Views;

public interface IDynamicObjectView : IObjectView
{
    ObjectGuid Caster { get; set; }
    Span<byte> Bytes { get; }
    int SpellId { get; set; }
    float Radius { get; set; }
}