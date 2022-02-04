using System;
using System.Threading.Tasks;

namespace MangosSharp.Server.Core.Sockets;

public interface ISocketHandler
{
    Task HandleConnect(SocketStream stream);
    Task HandleData(SocketStream stream);
    Task HandleDisconnect(SocketStream stream);
    Task HandleException(ISocketEndpoints endpoints, Exception e);
}