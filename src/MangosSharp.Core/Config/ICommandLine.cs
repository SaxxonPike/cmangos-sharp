using System.Collections.Generic;

namespace MangosSharp.Core.Config;

public interface ICommandLine
{
    IReadOnlyDictionary<string, IReadOnlyList<string>> Args { get; }
}