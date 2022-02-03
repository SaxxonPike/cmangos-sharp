using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

#pragma warning disable CS4014

namespace MangosSharp.Server.Core.Sockets;

public sealed class SocketDaemon : ISocketDaemon
{
    private record struct Connection
    {
        public Socket Socket;
        public SocketStream Stream;
        public ISocketHandler Handler;
        public CancellationToken Cancel;
    }

    private readonly ILogger _logger;

    private readonly ConcurrentDictionary<string, Connection> _connections = new();

    public SocketDaemon(ILogger logger)
    {
        _logger = logger;
    }

    public Task ListenAsync(IPEndPoint endpoint, ISocketHandler handler, CancellationToken cancel)
    {
        return Task.Run(async () =>
        {
            var listener = new TcpListener(endpoint);
            listener.Start();
            while (!cancel.IsCancellationRequested)
            {
                var socket = await listener.AcceptSocketAsync(cancel);
                var socketEndpoint = socket.RemoteEndPoint?.ToString();
                var connection = new Connection
                {
                    Socket = socket,
                    Stream = new SocketStream(socket, cancel),
                    Cancel = cancel,
                    Handler = handler
                };
                _connections.AddOrUpdate(socketEndpoint, _ => connection, (_, _) => connection);

                Task.Run(async () =>
                {
                    await ConnectSocketAsync(connection);
                    while (socket.Connected)
                    {
                        socket.Receive(Span<byte>.Empty, SocketFlags.None, out var socketError);
                        var available = socket.Available;

                        if (available == 0 || socketError != SocketError.Success || cancel.IsCancellationRequested)
                            break;

                        await ReceiveSocketAsync(connection);
                    }

                    await CleanUpSocketAsync(connection);
                    _connections.TryRemove(socketEndpoint, out _);
                    return Task.CompletedTask;
                }, cancel);
            }

            return Task.CompletedTask;
        }, cancel);
    }

    private static Task ConnectSocketAsync(Connection connection) =>
        Task.Run(() =>
        {
            try
            {
                connection.Handler.HandleConnect(connection.Stream);
            }
            catch (Exception ie)
            {
                connection.Handler.HandleException(connection.Stream, ie);
            }
        }, connection.Cancel);

    private static Task ReceiveSocketAsync(Connection connection) =>
        Task.Run(() =>
        {
            try
            {
                connection.Handler.HandleData(connection.Stream);
            }
            catch (Exception ie)
            {
                connection.Handler.HandleException(connection.Stream, ie);
            }
        }, connection.Cancel);

    private static Task CleanUpSocketAsync(Connection connection)
    {
        return Task.Run(() =>
        {
            try
            {
                connection.Socket.Close();
                connection.Handler.HandleDisconnect(connection.Stream);
            }
            catch (Exception ie)
            {
                connection.Handler.HandleException(connection.Stream, ie);
            }
        }, connection.Cancel);
    }

    public Task SendAsync(IPEndPoint endPoint, Action<SocketStream> func, CancellationToken cancel)
    {
        var socketEndPoint = endPoint.ToString();
        if (!_connections.TryGetValue(socketEndPoint, out var connection))
            throw new Exception("Socket is not available");

        return Task.Run(() =>
        {
            try
            {
                func?.Invoke(connection.Stream);
            }
            catch (Exception e)
            {
                connection.Handler.HandleException(connection.Stream, e);
            }
        }, cancel);
    }
}