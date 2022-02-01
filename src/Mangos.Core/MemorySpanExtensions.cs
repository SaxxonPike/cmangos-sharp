using System;
using System.Text;

// ReSharper disable UnusedMember.Global

namespace Mangos.Core;

public static class MemorySpanExtensions
{
    public static ReadOnlyMemory<byte> NullTerminated(this ReadOnlyMemory<byte> bytes)
    {
        for (var i = 0; i < bytes.Length; i++)
            if (bytes.Span[i] == 0)
                return bytes[..i];
        return bytes;
    }

    public static Memory<byte> NullTerminated(this Memory<byte> bytes)
    {
        for (var i = 0; i < bytes.Length; i++)
            if (bytes.Span[i] == 0)
                return bytes[..i];
        return bytes;
    }

    public static ReadOnlySpan<byte> NullTerminated(this ReadOnlySpan<byte> bytes)
    {
        for (var i = 0; i < bytes.Length; i++)
            if (bytes[i] == 0)
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

    public static Memory<byte> NullTerminated(this byte[] bytes)
    {
        var span = bytes.AsMemory();
        for (var i = 0; i < bytes.Length; i++)
            if (bytes[i] == 0)
                return span[..i];
        return bytes;
    }

    public static byte[] ToUtf8Bytes(this ReadOnlySpan<char> chars)
    {
        var utf8 = Encoding.UTF8;
        var buffer = new byte[utf8.GetByteCount(chars)];
        utf8.GetBytes(chars, buffer);
        return buffer;
    }

    public static byte[] ToUtf8Bytes(this Span<char> chars) =>
        ToUtf8Bytes((ReadOnlySpan<char>)chars);

    public static byte[] ToUtf8Bytes(this ReadOnlyMemory<char> chars) =>
        ToUtf8Bytes(chars.Span);

    public static byte[] ToUtf8Bytes(this Memory<char> chars) =>
        ToUtf8Bytes((ReadOnlySpan<char>)chars.Span);

    public static string ToUtf8String(this ReadOnlySpan<byte> bytes) =>
        Encoding.UTF8.GetString(bytes);

    public static string ToUtf8String(this Span<byte> bytes) =>
        ToUtf8String((ReadOnlySpan<byte>)bytes);

    public static string ToUtf8String(this ReadOnlyMemory<byte> bytes) =>
        ToUtf8String(bytes.Span);

    public static string ToUtf8String(this Memory<byte> bytes) =>
        ToUtf8String((ReadOnlySpan<byte>)bytes.Span);

    public static byte[] Reversed(this ReadOnlySpan<byte> bytes)
    {
        var result = new byte[bytes.Length];
        for (var i = 0; i < bytes.Length; i++)
            result[^(i + 1)] = bytes[i];
        return result;
    }

    public static byte[] Reversed(this Span<byte> bytes) =>
        Reversed((ReadOnlySpan<byte>)bytes);

    public static byte[] Reversed(this ReadOnlyMemory<byte> bytes) =>
        Reversed(bytes.Span);

    public static byte[] Reversed(this Memory<byte> bytes) =>
        Reversed((ReadOnlySpan<byte>)bytes.Span);
}