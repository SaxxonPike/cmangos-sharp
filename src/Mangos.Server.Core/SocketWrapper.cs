using System;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Mangos.Server.Core;

public sealed class SocketWrapper : ISocketIngress, ISocketEgress, ISocketEndpoints
{
    private readonly Socket _socket;
    private readonly CancellationToken _cancel;

    public SocketWrapper(Socket socket, CancellationToken cancel)
    {
        _socket = socket;
        _cancel = cancel;
        LocalEndPoint = _socket.LocalEndPoint?.ToString();
        RemoteEndPoint = _socket.RemoteEndPoint?.ToString();
    }

    public int Available => _socket.Available;
    public string LocalEndPoint { get; }
    public string RemoteEndPoint { get; }

    public Task<int> Receive(Memory<byte> buffer) => _socket.ReceiveAsync(buffer, SocketFlags.None, _cancel).AsTask();
    public Task<int> Send(ReadOnlyMemory<byte> buffer) => _socket.SendAsync(buffer, SocketFlags.None, _cancel).AsTask();
    public Task Close() => Task.Run(() => _socket.Close(), _cancel);
}