using System.Net;

namespace Mangos.Server.Core.Sockets;

public sealed class SocketEndpoints : ISocketEndpoints
{
    public SocketEndpoints(IPEndPoint local, IPEndPoint remote)
    {
        LocalEndPoint = local.ToString();
        RemoteEndPoint = remote.ToString();
    }

    public string LocalEndPoint { get; }
    public string RemoteEndPoint { get; }
}