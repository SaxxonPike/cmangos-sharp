using System.IO;
using System.Threading;
using MangosSharp.Server.Core.Sockets;

namespace MangosSharp.Server.Core.Messages;

public interface IPacketHandler
{
    bool Handle(Stream stream, CancellationToken cancel);
}