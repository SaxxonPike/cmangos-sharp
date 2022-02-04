using System.Collections.Generic;

namespace MangosSharp.Server.Core.Cli;

public interface ICliCommands
{
    IReadOnlyDictionary<string, CliCommand> Commands { get; }
}