﻿using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Mangos.Server.Core.Sockets;

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
        _logger.LogInformation("Launching socket daemon: endpoint={}", endpoint);
        
        // ReSharper disable once LocalFunctionHidesMethod
        SocketStream GetWrapper(string socketEndPoint, Socket socket) =>
            this.GetWrapper(socketEndPoint, socket, cancel);

        void StartHandlerLoopAsync()
        {
            _logger.LogDebug("{} started", nameof(StartHandlerLoopAsync));
            
            while (true)
            {
                SpinWait.SpinUntil(() => cancel.IsCancellationRequested, 1);
                if (cancel.IsCancellationRequested)
                    break;

                foreach (var (socketEndPoint, socket) in _sockets.ToList())
                {
                    try
                    {
                        // Socket ingress.
                        if (IsLocked(socketEndPoint))
                            continue;

                        if (socket.Connected && socket.Available > 0)
                        {
                            IncrementLock(socketEndPoint);
                            ThreadPool.QueueUserWorkItem(s =>
                            {
                                var wrapper = GetWrapper(socketEndPoint, s);
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
                            }, socket, false);
                        }

                        if (socket.Connected)
                            continue;
                    }
                    catch (Exception)
                    {
                        // Do nothing, continue loop.
                    }

                    try
                    {
                        // Socket cleanup.
                        IncrementLock(socketEndPoint);
                        ThreadPool.QueueUserWorkItem(s =>
                        {
                            var wrapper = GetWrapper(socketEndPoint, socket);
                            try
                            {
                                s.Close();
                                handler.HandleDisconnect(wrapper);
                            }
                            catch (Exception ie)
                            {
                                handler.HandleException(wrapper, ie);
                            }
                            finally
                            {
                                _wrappers.TryRemove(socketEndPoint, out _);
                                _sockets.TryRemove(socketEndPoint, out _);
                                _locks.TryRemove(socketEndPoint, out _);
                            }
                        }, socket, false);
                    }
                    catch (Exception)
                    {
                        // Do nothing, continue loop.
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
                        ThreadPool.QueueUserWorkItem(s => { s.Close(); }, socket, false);
                        continue;
                    }

                    var socket0 = _sockets.AddOrUpdate(socketEndPoint,
                        _ => socket,
                        (_, existing) =>
                        {
                            existing?.Close();
                            return socket;
                        });

                    IncrementLock(socketEndPoint);
                    ThreadPool.QueueUserWorkItem(s =>
                    {
                        var wrapper = GetWrapper(socketEndPoint, s);
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
                    }, socket0, false);
                }
                catch (Exception e)
                {
                    handler.HandleException(new SocketEndpoints((IPEndPoint)listener.LocalEndpoint, default), e);
                }
            }
            
            _logger.LogDebug("{} stopped", nameof(StartSocketLoopAsync));
        }

        var socketLoop = new Task(StartSocketLoopAsync, cancel, TaskCreationOptions.LongRunning);
        var handlerLoop = new Task(StartHandlerLoopAsync, cancel, TaskCreationOptions.LongRunning);

        socketLoop.Start();
        handlerLoop.Start();
        
        return Task.WhenAll(socketLoop, handlerLoop);
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