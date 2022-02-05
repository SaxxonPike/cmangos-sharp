using System;
using System.Collections.Generic;
using MangosSharp.Core;
using MangosSharp.Server.Core.Enums;

namespace MangosSharp.Server.Core.Views;

public interface IObjectView : IViewBase
{
    ObjectGuid Guid { get; set; }
    TypeMask TypeMask { get; set; }
    int Entry { get; set; }
    float ScaleX { get; set; }
    
    UpdateFlags UpdateFlags { get; }
    int OwnerAccount { get; set; }
    ObjectGuid Owner { get; set; }
    IMovementView Movement { get; }
    ILocationView Location { get; }
    IMovementSpeedView Speed { get; }
    TypeId TypeId { get; }
    int MapId { get; set; }
    int AreaId { get; set; }

    List<ObjectGuid> VisibleGuids { get; }
    ReadOnlySpan<int> GetMaskForCreate();
}