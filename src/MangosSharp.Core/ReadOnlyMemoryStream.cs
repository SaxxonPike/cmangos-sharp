using System;
using System.IO;

namespace MangosSharp.Core;

public sealed class ReadOnlyMemoryStream : Stream
{
    private readonly ReadOnlyMemory<byte> _bytes;
    private int _offset;

    public ReadOnlyMemoryStream(ReadOnlyMemory<byte> bytes)
    {
        _bytes = bytes;
    }

    public override void Flush()
    {
    }

    public override int Read(byte[] buffer, int offset, int count)
    {
        var span = _bytes.Span[_offset..];
        if (span.Length > count)
        {
            span[..count].CopyTo(buffer);
            _offset += count;
            return count;
        }

        span.CopyTo(buffer);
        _offset += span.Length;
        return span.Length;
    }

    public override long Seek(long offset, SeekOrigin origin)
    {
        switch (origin)
        {
            case SeekOrigin.Begin:
                _offset = (int)offset;
                break;
            case SeekOrigin.Current:
                _offset += (int)offset;
                break;
            case SeekOrigin.End:
            default:
                throw new NotImplementedException();
        }

        return _offset;
    }

    public override void SetLength(long value) => throw new NotImplementedException();
    public override void Write(byte[] buffer, int offset, int count) => throw new NotImplementedException();

    public override bool CanRead => true;
    public override bool CanSeek => true;
    public override bool CanWrite => false;
    public override long Length => _bytes.Length;

    public override long Position
    {
        get => _offset;
        set => _offset = (int)value;
    }
}