using System;
using System.Runtime.InteropServices;

namespace MangosSharp.Server.Core.Views;

public abstract class ViewBase : IViewBase
{
    private readonly Memory<int> _fields;
    private readonly int[] _dirtyBits;

    protected ViewBase(int fieldCount) : this(new int[fieldCount])
    {
    }

    protected ViewBase(Memory<int> fields)
    {
        _fields = fields;
        _dirtyBits = new int[(_fields.Length >> 5) + 1];
        
    }

    public Span<byte> RawBytes => MemoryMarshal.Cast<int, byte>(_fields.Span);

    public Memory<int> RawFields => _fields;

    public void Invalidate(int index) => _dirtyBits[index >> 5] |= 1 << (index & 0x1F);

    public void Invalidate(int index, int count)
    {
        for (var i = 0; i < count; i++)
            _dirtyBits[index >> 5] |= 1 << (index & 0x1F);
    }

    public void Invalidate(ReadOnlySpan<int> indices)
    {
        foreach (var index in indices)
            _dirtyBits[index >> 5] |= 1 << (index & 0x1F);
    }

    public void InvalidateMask(ReadOnlySpan<int> mask)
    {
        for (var i = 0; i < mask.Length; i++)
            _dirtyBits[i] |= mask[i];
    }

    public ReadOnlySpan<int> DirtyBits => _dirtyBits;

    private readonly int[] DefaultResetMask = Array.Empty<int>();

    protected virtual ReadOnlySpan<int> ResetMask => DefaultResetMask;

    public static Memory<int> GenerateMask(params int[] fields)
    {
        var result = new int[(fields.Length + 31) >> 5];
        foreach (var field in fields)
        {
            var bitfieldIndex = field >> 5;
            var bit = 1 << (field & 0x1F);
            result[bitfieldIndex] |= 1 << bit;
        }

        return result;
    }

    public void Validate()
    {
        _dirtyBits.AsSpan().Fill(0);
        ResetMask.CopyTo(_dirtyBits);
    }

    public virtual int GetValueForUpdate(int index) => _fields.Span[index];

    public ReadOnlySpan<int> GetMaskForCreate()
    {
        // var length = _fields.Length;
        // var size = (length + 31) >> 5;
        // var result = new int[size];
        //
        // // var idx = 0;
        // // var b = 1;
        // //
        // // for (var i = 0; i < length; i++)
        // // {
        // //     if (_fields.Span[i] != default)
        // //         result[idx] |= b;
        // //
        // //     b <<= 1;
        // //     if (b != 0)
        // //         continue;
        // //
        // //     b = 1;
        // //     idx++;
        // // }
        //
        // for (var i = 0; i < size - 1; i++)
        //     result[i] = -1;
        //
        // var remainder = _fields.Length & 0x1F;
        // if (remainder != 0)
        //     result[size - 1] = (1 << remainder) - 1;
        //
        // return result;

        return _dirtyBits;
    }

    protected long GetLong(int index) =>
        MemoryMarshal.Cast<int, long>(_fields.Span[index..])[0];

    protected void SetLong(int index, long value)
    {
        Invalidate(index);
        Invalidate(index + 1);
        MemoryMarshal.Cast<int, long>(_fields.Span[index..])[0] = value;
    }

    protected float GetFloat(int index) =>
        MemoryMarshal.Cast<int, float>(_fields.Span)[index];

    protected float SetFloat(int index, float value)
    {
        Invalidate(index);
        return MemoryMarshal.Cast<int, float>(_fields.Span)[index] = value;
    }

    protected int GetInt(int index) =>
        _fields.Span[index];

    protected int SetInt(int index, int value)
    {
        Invalidate(index);
        return _fields.Span[index] = value;
    }

    protected Span<int> GetInts(int index, int size) =>
        _fields.Slice(index, size).Span;

    protected Span<float> GetFloats(int index, int size) =>
        MemoryMarshal.Cast<int, float>(_fields.Slice(index, size).Span);

    protected Span<long> GetLongs(int index, int size) =>
        MemoryMarshal.Cast<int, long>(_fields.Slice(index, size).Span);

    protected Span<short> GetShorts(int index, int size) =>
        MemoryMarshal.Cast<int, short>(_fields.Slice(index, size).Span);

    protected Span<byte> GetBytes(int index, int size) =>
        MemoryMarshal.Cast<int, byte>(_fields.Slice(index, size).Span);

    protected void SetByte(int index, int offset, byte value)
    {
        Invalidate(index);
        MemoryMarshal.Cast<int, byte>(_fields[index..].Span)[offset] = value;
    }

    protected byte GetByte(int index, int offset) =>
        MemoryMarshal.Cast<int, byte>(_fields[index..].Span)[offset];

    protected bool GetBit(int index, int bit) =>
        ((_fields.Span[index] >> bit) & 1) != 0;

    protected void SetBit(int index, int bit, bool value)
    {
        if (value)
            _fields.Span[index] |= 1 << bit;
        else
            _fields.Span[index] &= ~(1 << bit);
    }
}