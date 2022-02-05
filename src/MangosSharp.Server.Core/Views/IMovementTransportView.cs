using MangosSharp.Core;

namespace MangosSharp.Server.Core.Views;

public interface IMovementTransportView
{
    ObjectGuid Guid { get; set; }
    ILocationView Location { get; }
    int Timestamp { get; set; }
}