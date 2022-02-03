using System;
using System.Collections.Generic;
using System.IO;

namespace MangosSharp.Server.Core.Cli;

public sealed class CliCommand
{
    public string Description { get; init; } = "No description available.";
    public IReadOnlyDictionary<string, CliCommand> Commands { get; init; }
    public IReadOnlyDictionary<string, CliParameter> Parameters { get; init; }
    public bool RepeatLastParameter { get; init; } = false;
    public Action<TextWriter, IReadOnlyDictionary<string, IReadOnlyList<string>>> Execute { get; init; }
}