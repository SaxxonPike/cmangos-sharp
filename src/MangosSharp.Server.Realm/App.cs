using System.Net;
using MangosSharp.Core.Infrastructure;
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
    private readonly AppCancellation _appCancellation;
    private readonly CliCommands _cliCommands;

    public App(ILogger logger, ISocketHandler socketHandler, ISocketDaemon socketDaemon, IConfiguration configuration,
        IConsoleProvider consoleProvider, ICliParser cliParser, AppCancellation appCancellation,
        CliCommands cliCommands)
    {
        _logger = logger;
        _socketHandler = socketHandler;
        _socketDaemon = socketDaemon;
        _configuration = configuration;
        _consoleProvider = consoleProvider;
        _cliParser = cliParser;
        _appCancellation = appCancellation;
        _cliCommands = cliCommands;
    }

    public void Run(string[] args)
    {
        _logger.LogInformation("Realm server args ({}) {}", args.Length, string.Join(" ", args));

        var worldEndpoint = new IPEndPoint(
            IPAddress.Parse(_configuration["BindIP"]),
            int.Parse(_configuration["RealmServerPort"]));

        var listen = _socketDaemon.ListenAsync(worldEndpoint, _socketHandler, _appCancellation.Token);
        while (!_appCancellation.Token.IsCancellationRequested && !listen.IsCompleted)
        {
            _cliParser.Parse(_consoleProvider.Out, _consoleProvider.In.ReadLine(), _cliCommands.Commands);
        }
    }
}