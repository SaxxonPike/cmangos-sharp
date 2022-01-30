namespace Mangos.Server.Core.Sockets;

public interface ISocketEndpoints
{
    string LocalEndPoint { get; }
    string RemoteEndPoint { get; }
}