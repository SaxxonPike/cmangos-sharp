using System.IO;
using System.Threading;

namespace MangosSharp.Server.Core.Messages;

public interface IPacketHandler
{
    bool Handle(Stream stream, CancellationToken cancel);
}