using System;

namespace MangosSharp.Server.Core.Views;

public interface IContainerObjectView : IItemObjectView
{
    int Capacity { get; set; }
    
    Span<long> Slots { get; }
}