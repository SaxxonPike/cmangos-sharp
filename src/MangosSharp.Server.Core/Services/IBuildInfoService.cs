using System.Collections.Generic;

namespace MangosSharp.Server.Core.Services;

public interface IBuildInfoService
{
    IReadOnlyDictionary<int, RealmBuildInfo> Builds { get; }
}