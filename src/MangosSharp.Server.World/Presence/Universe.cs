using System;
using System.Collections.Generic;
using System.Linq;
using MangosSharp.Core;
using MangosSharp.Server.Core.Views;

namespace MangosSharp.Server.World.Presence;

public class Universe : IUniverse
{
    private readonly Dictionary<HighGuid, Dictionary<int, object>> _tree = new();

    public void Add(IObjectView obj)
    {
        var counter = obj.Guid.Counter;
        if (counter == 0)
            throw new Exception("Zero counter guids are not valid");
        _tree[obj.Guid.High].Add(counter, obj);
    }

    public IObjectView Remove(ObjectGuid guid) => 
        _tree[guid.High].Remove(guid.Counter, out var result) ? result as IObjectView : default;

    public ICorpseObjectView GetCorpse(ObjectGuid guid) =>
        _tree[HighGuid.CORPSE].TryGetValue(guid.Counter, out var value)
            ? value as ICorpseObjectView
            : default;

    public IContainerObjectView GetContainer(ObjectGuid guid) =>
        _tree[HighGuid.CONTAINER].TryGetValue(guid.Counter, out var value)
            ? value as IContainerObjectView
            : default;

    public IItemObjectView GetItem(ObjectGuid guid) =>
        _tree[HighGuid.ITEM].TryGetValue(guid.Counter, out var value)
            ? value as IItemObjectView
            : default;

    public IPlayerObjectView GetPlayer(ObjectGuid guid) =>
        _tree[HighGuid.PLAYER].TryGetValue(guid.Counter, out var value)
            ? value as IPlayerObjectView
            : default;

    private IUnitObjectView GetPetInternal(ObjectGuid guid) =>
        _tree[HighGuid.PET].TryGetValue(guid.Counter, out var value)
            ? value as IUnitObjectView
            : default;

    private IUnitObjectView GetCreatureInternal(ObjectGuid guid) =>
        _tree[HighGuid.UNIT].TryGetValue(guid.Counter, out var value)
            ? value as IUnitObjectView
            : default;

    public IUnitObjectView GetUnit(ObjectGuid guid) =>
        guid.High switch
        {
            HighGuid.UNIT => GetCreatureInternal(guid),
            HighGuid.PLAYER => GetPlayer(guid),
            HighGuid.PET => GetPetInternal(guid),
            _ => default
        };

    public IPlayerObjectView GetPlayerByName(string name) =>
        _tree[HighGuid.PLAYER]
            .Select(x => x.Value)
            .FirstOrDefault(x => x is IPlayerObjectView player && player.Name == name) as IPlayerObjectView;
}