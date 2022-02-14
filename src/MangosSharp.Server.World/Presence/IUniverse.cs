using MangosSharp.Core;
using MangosSharp.Server.Core.Views;

namespace MangosSharp.Server.World.Presence;

public interface IUniverse
{
    void Add(IObjectView obj);
    IObjectView Remove(ObjectGuid guid);
    ICorpseObjectView GetCorpse(ObjectGuid guid);
    IContainerObjectView GetContainer(ObjectGuid guid);
    IItemObjectView GetItem(ObjectGuid guid);
    IPlayerObjectView GetPlayer(ObjectGuid guid);
    IUnitObjectView GetUnit(ObjectGuid guid);
    IPlayerObjectView GetPlayerByName(string name);
}