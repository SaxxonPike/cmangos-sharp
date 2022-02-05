using System;
using MangosSharp.Core;
using MangosSharp.Server.Core.Enums;

namespace MangosSharp.Server.Core.Views;

public interface IGameObjectView : IObjectView
{
    ObjectGuid CreatedBy { get; set; }
    int DisplayId { get; set; }
    int Flags { get; set; }
    Span<float> Rotations { get; }
    int State { get; set; }
    int DynFlags { get; set; }
    int Faction { get; set; }
    GameObjectType Type { get; set; }
    int Level { get; set; }
    int ArtKit { get; set; }
    int AnimProgress { get; set; }
    
    // server side only
    
    bool IsTransport { get; }
}