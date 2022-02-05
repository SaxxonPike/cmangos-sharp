using System;

namespace MangosSharp.Server.Core.Views;

public sealed class LocationView : ViewBase, ILocationView
{
    public LocationView() : this(new int[4])
    {
    }

    public LocationView(Memory<int> fields) : base(fields)
    {
    }
    
    public float X
    {
        get => GetFloat(0);
        set => SetFloat(0, value);
    }
    
    public float Y
    {
        get => GetFloat(1);
        set => SetFloat(1, value);
    }
    
    public float Z
    {
        get => GetFloat(2);
        set => SetFloat(2, value);
    }
    
    public float A
    {
        get => GetFloat(3);
        set => SetFloat(3, value);
    }
}