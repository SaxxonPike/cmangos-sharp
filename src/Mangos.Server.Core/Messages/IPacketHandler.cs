using System.IO;
using System.Threading;
using Mangos.Server.Core.Sockets;

namespace Mangos.Server.Core.Messages;

public interface IPacketHandler
{
    bool Handle(Stream stream, CancellationToken cancel);
}