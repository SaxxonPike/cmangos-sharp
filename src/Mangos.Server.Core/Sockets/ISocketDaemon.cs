using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Mangos.Server.Core.Sockets;

public interface ISocketDaemon
{
    Task ListenAsync(IPEndPoint endpoint, ISocketHandler handler, CancellationToken cancel);
    Task SendAsync(IPEndPoint endPoint, Action<ISocketEgress> func, CancellationToken cancel);
}