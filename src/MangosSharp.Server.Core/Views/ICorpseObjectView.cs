using System;

namespace MangosSharp.Server.Core.Views;

public interface ICorpseObjectView : IObjectView
{
    int DisplayId { get; set; }
    
    Span<int> Items { get; }
    
    Span<byte> Appearance { get; }
}