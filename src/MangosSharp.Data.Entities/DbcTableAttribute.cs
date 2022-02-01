using System;

namespace MangosSharp.Data.Entities;

[AttributeUsage(AttributeTargets.Class)]
public sealed class DbcTableAttribute : Attribute
{
    public string Name { get; }

    public DbcTableAttribute(string name)
    {
        Name = name;
    }
}