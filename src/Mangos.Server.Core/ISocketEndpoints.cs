namespace Mangos.Server.Core;

public interface ISocketEndpoints
{
    string LocalEndPoint { get; }
    string RemoteEndPoint { get; }
}