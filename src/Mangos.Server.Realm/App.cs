using System.Net;
using System.Threading;
using Mangos.Core.Infrastructure;
using Mangos.Server.Core.Sockets;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Mangos.Server.Realm;

public class App
{
    private readonly ILogger _logger;
    private readonly ISocketHandler _socketHandler;
    private readonly ISocketDaemon _socketDaemon;
    private readonly IConfiguration _configuration;
    private readonly IConsoleProvider _consoleProvider;

    public App(ILogger logger, ISocketHandler socketHandler, ISocketDaemon socketDaemon, IConfiguration configuration,
        IConsoleProvider consoleProvider)
    {
        _logger = logger;
        _socketHandler = socketHandler;
        _socketDaemon = socketDaemon;
        _configuration = configuration;
        _consoleProvider = consoleProvider;
    }
    
    public void Run(string[] args)
    {
        var worldEndpoint = new IPEndPoint(
            IPAddress.Parse(_configuration["BindIP"]),
            int.Parse(_configuration["RealmServerPort"]));

        var cancel = new CancellationTokenSource();
        _socketDaemon.ListenAsync(worldEndpoint, _socketHandler, cancel.Token);
        while (!cancel.IsCancellationRequested)
        {
            _consoleProvider.In.ReadLine();
            cancel.Cancel();
        }
    }
}