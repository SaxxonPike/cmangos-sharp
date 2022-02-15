using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace MangosSharp.Server.Core.Sockets;

/// <summary>
/// Acts as a broker for incoming and outgoing connections.
/// </summary>
public interface ISocketDaemon
{
    /// <summary>
    /// Spawn a listener at the specified local endpoint.
    /// </summary>
    /// <param name="endpoint">Endpoint to listen for TCP packets on.</param>
    /// <param name="handler">Will receive connect, disconnect and data messages.</param>
    /// <param name="cancel">A cancellation token that, when cancelled, will shut down all associated listeners and close all related connections.</param>
    /// <returns>A task which represents the listener that was created and started.</returns>
    Task ListenAsync(IPEndPoint endpoint, ISocketHandler handler, CancellationToken cancel);
    
    /// <summary>
    /// Send data to an active socket.
    /// </summary>
    /// <param name="endPoint">Remote endpoint to send data to.</param>
    /// <param name="func">Once the send comes up in the queue, this will be executed.</param>
    /// <param name="cancel">A cancellation token that, when cancelled, will abort transmitting the message.</param>
    /// <returns>A task which represents the send process.</returns>
    Task SendAsync(string endPoint, Action<SocketStream> func, CancellationToken cancel);

    /// <summary>
    /// Return the IP address from the input, resolving DNS if needed.
    /// </summary>
    /// <param name="hostOrIp">Hostname or IP address.</param>
    /// <param name="port">Network port.</param>
    /// <returns>IP address that was parsed/resolved.</returns>
    IPEndPoint ParseEndpoint(string hostOrIp, string port);
}