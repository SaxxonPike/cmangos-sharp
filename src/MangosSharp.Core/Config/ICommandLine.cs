using System.Collections.Generic;

namespace MangosSharp.Core.Config;

/// <summary>
/// Represents parsed command line arguments.
/// </summary>
public interface ICommandLine
{
    /// <summary>
    /// Gets all parsed command line arguments.
    /// </summary>
    IReadOnlyDictionary<string, IReadOnlyList<string>> Args { get; }
}