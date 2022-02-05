using System;

namespace MangosSharp.Server.Core.Views;

public interface IViewBase
{
    Memory<int> RawFields { get; }
    
    Span<byte> RawBytes { get; }

    void Invalidate(int index);

    void Invalidate(int index, int count);

    void Invalidate(ReadOnlySpan<int> indices);

    void InvalidateMask(ReadOnlySpan<int> mask);

    ReadOnlySpan<int> DirtyBits { get; }

    void Validate();

    int GetValueForUpdate(int index);
}