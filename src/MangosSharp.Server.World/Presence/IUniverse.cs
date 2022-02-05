using MangosSharp.Core;
using MangosSharp.Server.Core.Views;

namespace MangosSharp.Server.World.Presence;

public interface IUniverse
{
    void Add(IObjectView obj);
    IItemObjectView GetItem(ObjectGuid guid);
}