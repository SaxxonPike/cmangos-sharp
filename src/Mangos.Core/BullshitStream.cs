using System.IO;

namespace Mangos.Core;

/// <summary>
/// This is a bullshit stream- it will always let you read more bytes even past the end of the stream, but it
/// will still report the correct length and not advance the offset past the end. This prevents end of stream errors
/// in BinaryReader.
/// </summary>
public sealed class BullshitStream : Stream
{
    private readonly Stream _stream;

    public BullshitStream(Stream stream)
    {
        _stream = stream;
    }

    public override void Flush() => _stream.Flush();

    public override int Read(byte[] buffer, int offset, int count)
    {
        var bytesRead = _stream.Read(buffer, offset, count);
        for (var i = bytesRead; i < count; i++)
            buffer[offset + i] = default;
        return count;
    }

    public override long Seek(long offset, SeekOrigin origin) => _stream.Seek(offset, origin);

    public override void SetLength(long value) => _stream.SetLength(value);

    public override void Write(byte[] buffer, int offset, int count) => _stream.Write(buffer, offset, count);

    public override bool CanRead => _stream.CanRead;
    public override bool CanSeek => _stream.CanSeek;
    public override bool CanWrite => _stream.CanWrite;
    public override long Length => _stream.Length;

    public override long Position
    {
        get => _stream.Position;
        set => _stream.Position = value;
    }

    protected override void Dispose(bool disposing)
    {
        _stream?.Dispose();
        base.Dispose(disposing);
    }
}