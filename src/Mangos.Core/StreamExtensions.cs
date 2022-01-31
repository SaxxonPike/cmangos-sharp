using System;
using System.IO;

namespace Mangos.Core;

public static class StreamExtensions
{
    public static BullshitStream Bullshit(this Stream stream) => new(stream);

    public static Span<byte> AsSpan(this MemoryStream stream) => AsMemory(stream).Span;

    public static Memory<byte> AsMemory(this MemoryStream stream)
    {
        if (!stream.TryGetBuffer(out var seg))
            throw new Exception("Can't GetBuffer on this MemoryStream.");
        return seg.AsMemory();
    }
}