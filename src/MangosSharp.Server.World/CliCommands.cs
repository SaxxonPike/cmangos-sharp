using System.Collections.Generic;
using MangosSharp.Server.Core.Cli;

namespace MangosSharp.Server.World;

public sealed class CliCommands : ICliCommands
{
    public CliCommands()
    {
        Commands = new Dictionary<string, CliCommand>();
    }

    public IReadOnlyDictionary<string, CliCommand> Commands { get; }
}