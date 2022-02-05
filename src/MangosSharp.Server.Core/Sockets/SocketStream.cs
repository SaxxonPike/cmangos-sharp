using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MangosSharp.Core;

namespace MangosSharp.Server.Core.Sockets;

public sealed class SocketStream : Stream, ISocketEndpoints
{
    private readonly Socket _socket;
    private readonly CancellationToken _cancel;
    private BinaryReader _reader;
    private BinaryWriter _writer;
    private long _position;
    private readonly MemoryStream _outputBuffer;
    private readonly MemoryStream _inputBuffer;
    private long _inputBufferIndex;
    private readonly Dictionary<string, object> _metadata;

    public SocketStream(string localEndPoint, string remoteEndpoint, Socket socket, CancellationToken cancel)
    {
        _metadata = new Dictionary<string, object>();
        _socket = socket;
        _cancel = cancel;
        _outputBuffer = new MemoryStream();
        _inputBuffer = new MemoryStream();
        _inputBufferIndex = 0;
        RemoteEndPoint = remoteEndpoint;
        LocalEndPoint = localEndPoint;
    }

    public int Available => (int)(_inputBuffer.Length - _inputBufferIndex) +
                            (_socket?.Connected ?? false ? _socket.Available : 0);

    public string LocalEndPoint { get; }
    public string RemoteEndPoint { get; }

    public void Disconnect() => _socket?.Close();

    public BinaryReader Reader => _reader ??= new BinaryReader(this, Encoding.UTF8);
    public BinaryWriter Writer => _writer ??= new BinaryWriter(_outputBuffer, Encoding.UTF8);

    public override void Flush()
    {
        lock (_outputBuffer)
        {
            if (_socket.Connected)
                _socket.Send(_outputBuffer.AsSpan());
            _outputBuffer.Position = 0;
            _outputBuffer.SetLength(0);
        }
    }

    public void Discard()
    {
        lock (_inputBuffer)
        {
            _inputBuffer.Position = 0;
            _inputBuffer.SetLength(0);
            _inputBufferIndex = 0;
        }
    }

    public async Task<int> Read(Memory<byte> buffer)
    {
        // Take bytes from the internal buffer first.
        var copyLength = (int)Math.Min(buffer.Length, _inputBuffer.Length - _inputBufferIndex);
        if (copyLength > 0)
        {
            _inputBuffer.AsSpan().Slice((int)_inputBufferIndex, copyLength).CopyTo(buffer.Span);
            _inputBufferIndex += copyLength;
            buffer = buffer[copyLength..];
            _position += copyLength;

            // If we only need to read from the buffer, don't bother using the socket.
            if (buffer.Length == 0)
                return copyLength;
        }

        // Read the rest from the socket itself.
        var result = await _socket.ReceiveAsync(buffer, SocketFlags.None, _cancel);
        _position += result;
        return result;
    }

    // // ReSharper disable once UnusedMethodReturnValue.Global
    // public async Task<int> Read(Memory<byte> buffer, CancellationToken cancel)
    // {
    //     using var compoundToken = CancellationTokenSource.CreateLinkedTokenSource(_cancel, cancel);
    //     var result = await _socket.ReceiveAsync(buffer, SocketFlags.None, compoundToken.Token);
    //     _position += result;
    //     return result;
    // }

    public override int Read(byte[] buffer, int offset, int count)
    {
        // ReSharper disable once MethodSupportsCancellation
        var task = Read(buffer.AsMemory(offset, count));
        SpinWait.SpinUntil(() => task.IsCompleted);
        return task.Result;
    }

    public override long Seek(long offset, SeekOrigin origin) =>
        throw new NotImplementedException();

    public override void SetLength(long value) =>
        throw new NotImplementedException();

    public async Task<int> Write(Memory<byte> buffer) =>
        await _socket.SendAsync(buffer, SocketFlags.None, _cancel);

    public override void Write(byte[] buffer, int offset, int count)
    {
        // ReSharper disable once MethodSupportsCancellation
        var task = Write(buffer.AsMemory(offset, count));
        SpinWait.SpinUntil(() => task.IsCompleted);
    }

    public override bool CanRead => true;
    public override bool CanSeek => false;
    public override bool CanWrite => true;
    public override long Length => _socket.Available;

    public override long Position
    {
        get => _position;
        set => throw new NotImplementedException();
    }

    protected override void Dispose(bool disposing)
    {
        _metadata.Clear();
        _inputBuffer.Dispose();
        _outputBuffer.Dispose();
        base.Dispose(disposing);
    }

    public void SetMetadata(string key, object value) => _metadata[key] = value;

    public T GetMetadata<T>(string key) => _metadata.TryGetValue(key, out var value) ? (T)value : default;

    public T GetAndClearMetadata<T>(string key)
    {
        var result = GetMetadata<T>(key);
        ClearMetadata(key);
        return result;
    }

    public void ClearMetadata(string key) => _metadata.Remove(key);

    public void Insert(ReadOnlySpan<byte> data)
    {
        _inputBuffer.Write(data);
    }
}