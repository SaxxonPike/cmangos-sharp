using System.Collections.Generic;
using System.IO;
using MangosSharp.Server.Core;
using MangosSharp.Server.Core.Cli;

namespace MangosSharp.Server.World;

public sealed class CliCommands : ICliCommands
{
    private readonly IAppCancellation _appCancellation;

    public CliCommands(IAppCancellation appCancellation)
    {
        _appCancellation = appCancellation;
        Commands = new Dictionary<string, CliCommand>
        {
            {
                "exit",
                new CliCommand
                {
                    Description = "Stops the server.",
                    Execute = Exit
                }
            },
            
        };
    }

    private void Exit(TextWriter output, IReadOnlyDictionary<string, IReadOnlyList<string>> parameters)
    {
        _appCancellation.Cancel();
    }

    public IReadOnlyDictionary<string, CliCommand> Commands { get; }
}