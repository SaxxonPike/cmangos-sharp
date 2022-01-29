using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Mangos.Server.Core;

public interface ISocketDaemon
{
    Task ListenAsync(IPEndPoint endpoint, ISocketHandler handler, CancellationToken cancel);
    void Send(IPEndPoint endPoint, Action<ISocketEgress> func, CancellationToken cancel);
}