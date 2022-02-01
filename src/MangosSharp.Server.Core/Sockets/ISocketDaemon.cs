using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace MangosSharp.Server.Core.Sockets;

public interface ISocketDaemon
{
    Task ListenAsync(IPEndPoint endpoint, ISocketHandler handler, CancellationToken cancel);
    Task SendAsync(IPEndPoint endPoint, Action<SocketStream> func, CancellationToken cancel);
}