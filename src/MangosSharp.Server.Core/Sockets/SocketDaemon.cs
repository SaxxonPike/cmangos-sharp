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
    private readonly ILogger _logger;

    private readonly ConcurrentDictionary<string, Socket> _sockets = new();
    private readonly ConcurrentDictionary<string, int> _locks = new();
    private readonly ConcurrentDictionary<string, SocketStream> _wrappers = new();

    public SocketDaemon(ILogger logger)
    {
        _logger = logger;
    }

    private SocketStream GetWrapper(string socketEndPoint, Socket socket, CancellationToken cancel) =>
        _wrappers.AddOrUpdate(socketEndPoint, _ => new SocketStream(socket, cancel), (_, w) => w);

    private void IncrementLock(string socketEndPoint) =>
        _locks.AddOrUpdate(socketEndPoint, _ => 1, (_, v) => v + 1);

    private void DecrementLock(string socketEndPoint) =>
        _locks.AddOrUpdate(socketEndPoint, _ => 0, (_, v) => v - 1);

    private bool IsLocked(string socketEndPoint) =>
        _locks.TryGetValue(socketEndPoint, out var count) && count > 0;

    public Task ListenAsync(IPEndPoint endpoint, ISocketHandler handler, CancellationToken cancel)
    {
        void StartHandlerLoopAsync()
        {
            _logger.LogDebug("{} started", nameof(StartHandlerLoopAsync));

            while (true)
            {
                SpinWait.SpinUntil(() => cancel.IsCancellationRequested, 1);
                if (cancel.IsCancellationRequested)
                    break;

                foreach (var (socketEndPoint, socket) in _sockets)
                {
                    // Socket ingress.
                    try
                    {
                        if (IsLocked(socketEndPoint))
                            continue;

                        if (socket.Connected && socket.Available > 0)
                            ReceiveSocketAsync(socketEndPoint, socket, handler, cancel);
                    }
                    catch (Exception e)
                    {
                        // handled in async
                    }

                    // Socket cleanup.
                    try
                    {
                        if (socket.Connected)
                            continue;

                        CleanUpSocketAsync(socketEndPoint, socket, handler, cancel);
                    }
                    catch (Exception e)
                    {
                        // handled in async
                    }
                }
            }

            _logger.LogDebug("{} stopped", nameof(StartHandlerLoopAsync));
        }

        async void StartSocketLoopAsync()
        {
            _logger.LogDebug("{} started", nameof(StartSocketLoopAsync));

            var listener = new TcpListener(endpoint);
            listener.Start();
            while (true)
            {
                try
                {
                    var socket = await listener.AcceptSocketAsync(cancel);
                    if (cancel.IsCancellationRequested)
                        break;

                    var socketEndPoint = socket.RemoteEndPoint?.ToString();
                    if (socketEndPoint == default)
                    {
                        CloseSocketAsync(socket);
                        continue;
                    }

                    var socket0 = _sockets.AddOrUpdate(socketEndPoint,
                        _ => socket,
                        (_, existing) =>
                        {
                            existing?.Close();
                            return socket;
                        });

                    ConnectSocketAsync(socketEndPoint, socket0, handler, cancel);
                }
                catch (Exception e)
                {
                    handler.HandleException(new SocketEndpoints(
                        listener.LocalEndpoint as IPEndPoint, default), e);
                }
            }

            _logger.LogDebug("{} stopped", nameof(StartSocketLoopAsync));
        }


        var task = new Task<Task>(() =>
        {
            _logger.LogWarning("Started socket daemon: endpoint={}", endpoint);
            var socketLoop = new Task(StartSocketLoopAsync, cancel, TaskCreationOptions.LongRunning);
            var handlerLoop = new Task(StartHandlerLoopAsync, cancel, TaskCreationOptions.LongRunning);
            socketLoop.Start();
            handlerLoop.Start();
            return Task.WhenAll(socketLoop, handlerLoop);
        });

        task.Unwrap()
            .ContinueWith(t =>
            {
                _logger.LogWarning("Stopped socket daemon: endpoint={}", endpoint);
                if (t.Exception is { } exception)
                    _logger.LogWarning("Socket daemon reported exception: {}", exception);
            }, TaskContinuationOptions.ExecuteSynchronously);

        task.Start();
        return task;
    }

    private Task ConnectSocketAsync(string socketEndPoint, Socket socket, ISocketHandler handler, CancellationToken cancel)
    {
        IncrementLock(socketEndPoint);

        return Task.Run(() =>
        {
            var wrapper = GetWrapper(socketEndPoint, socket, cancel);
            try
            {
                handler.HandleConnect(wrapper);
            }
            catch (Exception ie)
            {
                handler.HandleException(wrapper, ie);
            }
            finally
            {
                DecrementLock(socketEndPoint);
            }
        }, cancel);
    }

    private Task CloseSocketAsync(Socket socket) =>
        Task.Run(socket.Close);

    private Task ReceiveSocketAsync(string socketEndPoint, Socket socket, ISocketHandler handler, CancellationToken cancel)
    {
        IncrementLock(socketEndPoint);

        return Task.Run(() =>
        {
            var wrapper = GetWrapper(socketEndPoint, socket, cancel);
            try
            {
                handler.HandleData(wrapper);
            }
            catch (Exception ie)
            {
                handler.HandleException(wrapper, ie);
            }
            finally
            {
                DecrementLock(socketEndPoint);
            }
        }, cancel);
    }

    private Task CleanUpSocketAsync(string socketEndPoint, Socket socket, ISocketHandler handler, CancellationToken cancel)
    {
        IncrementLock(socketEndPoint);

        return Task.Run(() =>
        {
            var wrapper = GetWrapper(socketEndPoint, socket, cancel);
            try
            {
                socket.Close();
                handler.HandleDisconnect(wrapper);
            }
            catch (Exception ie)
            {
                handler.HandleException(wrapper, ie);
            }
            finally
            {
                _wrappers.TryRemove(socketEndPoint, out var w);
                _sockets.TryRemove(socketEndPoint, out var s);
                _locks.TryRemove(socketEndPoint, out _);
                w?.Dispose();
                s?.Dispose();
            }
        }, cancel);
    }

    public Task SendAsync(IPEndPoint endPoint, Action<SocketStream> func, CancellationToken cancel)
    {
        var socketEndPoint = endPoint.ToString();
        if (!_sockets.TryGetValue(socketEndPoint, out var socket))
            throw new Exception("Socket is not available");

        IncrementLock(socketEndPoint);
        return Task.Run(() =>
        {
            var wrapper = GetWrapper(socketEndPoint, socket, cancel);
            try
            {
                func?.Invoke(wrapper);
            }
            finally
            {
                DecrementLock(socketEndPoint);
            }
        }, cancel);
    }
}