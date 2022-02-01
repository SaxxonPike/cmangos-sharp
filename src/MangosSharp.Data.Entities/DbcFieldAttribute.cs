using System;

namespace MangosSharp.Data.Entities;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public sealed class DbcFieldAttribute : Attribute
{
    public int Index { get; }
    public int Length { get; }
    public int Offset { get; }
    public bool ClientOnly { get; }

    public DbcFieldAttribute(int index, int length = 1, int offset = 0, bool clientOnly = false)
    {
        Index = index;
        Offset = offset;
        ClientOnly = clientOnly;
        Length = length;
    }
}