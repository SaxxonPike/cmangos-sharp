using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Mangos.Server.Core;

public class SocketDaemon : ISocketDaemon
{
    private readonly ConcurrentDictionary<string, Socket> _sockets = new();
    private readonly ConcurrentDictionary<string, int> _locks = new();
    private readonly ConcurrentDictionary<string, SocketWrapper> _wrappers = new();

    private SocketWrapper GetWrapper(string socketEndPoint, Socket socket, CancellationToken cancel) => 
        _wrappers.AddOrUpdate(socketEndPoint, _ => new SocketWrapper(socket, cancel), (_, w) => w);

    private void IncrementLock(string socketEndPoint) => 
        _locks.AddOrUpdate(socketEndPoint, _ => 1, (_, v) => v + 1);

    private void DecrementLock(string socketEndPoint) => 
        _locks.AddOrUpdate(socketEndPoint, _ => 0, (_, v) => v - 1);

    public Task ListenAsync(IPEndPoint endpoint, ISocketHandler handler, CancellationToken cancel)
    {
        // ReSharper disable once LocalFunctionHidesMethod
        SocketWrapper GetWrapper(string socketEndPoint, Socket socket) => 
            this.GetWrapper(socketEndPoint, socket, cancel);

        void StartHandlerLoopAsync()
        {
            SpinWait.SpinUntil(() => cancel.IsCancellationRequested, 2000);
            
            foreach (var (socketEndPoint, socket) in _sockets.ToList())
            {
                try
                {
                    // Socket ingress.
                    if (socket.Connected && socket.Available > 0)
                    {
                        IncrementLock(socketEndPoint);
                        ThreadPool.QueueUserWorkItem(s =>
                        {
                            var wrapper = GetWrapper(socketEndPoint, s);
                            try
                            {
                                handler.HandleData(wrapper, wrapper);
                            }
                            catch (Exception ie)
                            {
                                handler.HandleException(wrapper ,ie);
                            }
                            finally
                            {
                                DecrementLock(socketEndPoint);
                            }
                        }, socket, false);
                    }

                    if (_locks.ContainsKey(socketEndPoint))
                        continue;

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

        async void StartSocketLoopAsync()
        {
            var listener = new TcpListener(endpoint);
            while (!cancel.IsCancellationRequested)
            {
                try
                {
                    var socket = await listener.AcceptSocketAsync(cancel);
                    if (cancel.IsCancellationRequested)
                        return;

                    var socketEndPoint = socket.RemoteEndPoint?.ToString();
                    if (socketEndPoint == default)
                    {
                        ThreadPool.QueueUserWorkItem(s =>
                        {
                            s.Close();
                        }, socket, false);
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
                        var wrapper = GetWrapper(socketEndPoint, socket0);
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
                    }, socket, false);
                }
                catch (Exception)
                {
                    // Do nothing, continue loop.
                }
            }
        }

        return Task.WhenAll(
            new Task(StartSocketLoopAsync, cancel, TaskCreationOptions.LongRunning),
            new Task(StartHandlerLoopAsync, cancel, TaskCreationOptions.LongRunning)
        );
    }

    public void Send(IPEndPoint endPoint, Action<ISocketEgress> func, CancellationToken cancel)
    {
        var socketEndPoint = endPoint.ToString();
        if (!_sockets.TryGetValue(socketEndPoint, out var socket))
            throw new Exception("Socket is not available");

        IncrementLock(socketEndPoint);
        ThreadPool.QueueUserWorkItem(_ =>
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
        });
    }

    public void Stop()
    {
        throw new NotImplementedException();
    }
}