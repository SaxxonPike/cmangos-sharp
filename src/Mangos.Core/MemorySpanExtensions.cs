using System;
using System.Text;

namespace Mangos.Core;

public static class MemorySpanExtensions
{
    public static Memory<byte> NullTerminated(this Memory<byte> bytes)
    {
        for (var i = 0; i < bytes.Length; i++)
            if (bytes.Span[i] == 0)
                return bytes[..i];
        return bytes;
    }
    
    public static Span<byte> NullTerminated(this Span<byte> bytes)
    {
        for (var i = 0; i < bytes.Length; i++)
            if (bytes[i] == 0)
                return bytes[..i];
        return bytes;
    }

    public static string ToUtf8String(this ReadOnlyMemory<byte> bytes)
        => Encoding.UTF8.GetString(bytes.Span);
    
    public static string ToUtf8String(this ReadOnlySpan<byte> bytes)
        => Encoding.UTF8.GetString(bytes);
    
    public static string ToUtf8String(this Memory<byte> bytes)
        => Encoding.UTF8.GetString(bytes.Span);
    
    public static string ToUtf8String(this Span<byte> bytes)
        => Encoding.UTF8.GetString(bytes);
}