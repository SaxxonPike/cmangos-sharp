using System;
using System.Net;
using MangosSharp.Core.Infrastructure;
using MangosSharp.Server.Core;
using MangosSharp.Server.Core.Cli;
using MangosSharp.Server.Core.Sockets;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MangosSharp.Server.World;

public class App
{
    private readonly IConfiguration _configuration;
    private readonly ISocketDaemon _socketDaemon;
    private readonly ISocketHandler _socketHandler;
    private readonly IConsoleProvider _consoleProvider;
    private readonly IAppCancellation _appCancellation;
    private readonly ICliParser _cliParser;
    private readonly ILogger _logger;
    private readonly ICliCommands _cliCommands;

    public App(IConfiguration configuration, ISocketDaemon socketDaemon, ISocketHandler socketHandler, 
        IConsoleProvider consoleProvider, IAppCancellation appCancellation, ICliParser cliParser, ILogger logger,
        ICliCommands cliCommands)
    {
        _configuration = configuration;
        _socketDaemon = socketDaemon;
        _socketHandler = socketHandler;
        _consoleProvider = consoleProvider;
        _appCancellation = appCancellation;
        _cliParser = cliParser;
        _logger = logger;
        _cliCommands = cliCommands;
    }

    public void Run()
    {
        var worldEndpoint = new IPEndPoint(
            IPAddress.Parse(_configuration["BindIP"]),
            int.Parse(_configuration["WorldServerPort"]));

        var listen = _socketDaemon.ListenAsync(worldEndpoint, _socketHandler, _appCancellation.Token);
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