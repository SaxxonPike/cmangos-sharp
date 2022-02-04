using System;
using System.Net;
using MangosSharp.Core.Config;
using MangosSharp.Core.Infrastructure;
using MangosSharp.Server.Core;
using MangosSharp.Server.Core.Cli;
using MangosSharp.Server.Core.Sockets;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MangosSharp.Server.Realm;

public class App
{
    private readonly ILogger _logger;
    private readonly ISocketHandler _socketHandler;
    private readonly ISocketDaemon _socketDaemon;
    private readonly IConfiguration _configuration;
    private readonly IConsoleProvider _consoleProvider;
    private readonly ICliParser _cliParser;
    private readonly IAppCancellation _appCancellation;
    private readonly ICliCommands _cliCommands;
    private readonly ICommandLine _commandLine;

    public App(ILogger logger, ISocketHandler socketHandler, ISocketDaemon socketDaemon, IConfiguration configuration,
        IConsoleProvider consoleProvider, ICliParser cliParser, IAppCancellation appCancellation,
        ICliCommands cliCommands, ICommandLine commandLine)
    {
        _logger = logger;
        _socketHandler = socketHandler;
        _socketDaemon = socketDaemon;
        _configuration = configuration;
        _consoleProvider = consoleProvider;
        _cliParser = cliParser;
        _appCancellation = appCancellation;
        _cliCommands = cliCommands;
        _commandLine = commandLine;
    }

    public void Run()
    {
        var realmEndpoint = new IPEndPoint(
            IPAddress.Parse(_configuration["BindIP"]),
            int.Parse(_configuration["RealmServerPort"]));

        var listen = _socketDaemon.ListenAsync(realmEndpoint, _socketHandler, _appCancellation.Token);
        while (!_appCancellation.Token.IsCancellationRequested && !listen.IsCompleted)
        {
            try
            {
                _cliParser.Parse(_consoleProvider.Out, _consoleProvider.In.ReadLine(), _cliCommands.Commands);
            }
            catch (Exception e)
            {
                // don't want CLI exceptions to crash the server
                _logger.LogError("CLI exception occurred: {}", e);
            }
        }
    }
}