using System;
using System.Collections.Generic;
using System.Linq;
using MangosSharp.Core;
using MangosSharp.Server.Core.Views;

namespace MangosSharp.Server.World.Presence;

public class Universe : IUniverse
{
    private readonly Dictionary<HighGuid, Dictionary<int, object>> _tree = new();

    public Universe()
    {
        // Populate branches
        foreach (var i in Enum.GetValues<HighGuid>().Distinct())
            _tree[i] = new Dictionary<int, object>();
    }

    public void Add(IObjectView obj)
    {
        var counter = obj.Guid.Counter;
        if (counter == 0)
            throw new Exception("Zero counter guids are not valid");
        _tree[obj.Guid.High].Add(counter, obj);
    }

    public IItemObjectView GetItem(ObjectGuid guid) => 
        _tree[HighGuid.ITEM].TryGetValue(guid.Counter, out var value) ? (IItemObjectView) value : default;
}