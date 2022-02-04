using System.Collections.Generic;
using System.IO;
using System.Linq;
using MangosSharp.Core.Security;
using MangosSharp.Server.Core;
using MangosSharp.Server.Core.Cli;
using MangosSharp.Server.Core.Services;

namespace MangosSharp.Server.Realm;

public sealed class CliCommands : ICliCommands
{
    private readonly IAppCancellation _appCancellation;
    private readonly IAuthService _authService;
    private readonly IDatabase _database;
    private readonly IAccountService _accountService;
    public IReadOnlyDictionary<string, CliCommand> Commands { get; }

    public CliCommands(IAppCancellation appCancellation, IAuthService authService, IDatabase database,
        IAccountService accountService)
    {
        _appCancellation = appCancellation;
        _authService = authService;
        _database = database;
        _accountService = accountService;

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
            {
                "account",
                new CliCommand
                {
                    Description = "Deals with accounts.",
                    Commands = new Dictionary<string, CliCommand>
                    {
                        {
                            "create",
                            new CliCommand
                            {
                                Description = "Create an account.",
                                Parameters = new Dictionary<string, CliParameter>
                                {
                                    {
                                        "username",
                                        new CliParameter
                                        {
                                            Description = "Username for the new account."
                                        }
                                    },
                                    {
                                        "password",
                                        new CliParameter
                                        {
                                            Description = "Password for the new account."
                                        }
                                    },
                                    {
                                        "email",
                                        new CliParameter
                                        {
                                            Description = "Email address for the new account.",
                                            Optional = true
                                        }
                                    }
                                },
                                Execute = AccountCreate
                            }
                        },
                        {
                            "delete",
                            new CliCommand
                            {
                                Description = "Delete an account.",
                                Parameters = new Dictionary<string, CliParameter>
                                {
                                    {
                                        "username",
                                        new CliParameter
                                        {
                                            Description = "Username for the account to delete."
                                        }
                                    }
                                },
                                Execute = AccountDelete
                            }
                        }
                    }
                }
            }
        };
    }

    private void Exit(TextWriter output, IReadOnlyDictionary<string, IReadOnlyList<string>> parameters)
    {
        _appCancellation.Cancel();
    }

    private void AccountCreate(TextWriter output, IReadOnlyDictionary<string, IReadOnlyList<string>> parameters)
    {
        var username = parameters["username"].Single().ToUpper();
        var password = parameters["password"].Single().ToUpper();
        var email = parameters["email"].Single();
        var account = _accountService.Create(username, password, email);
        output.WriteLine(account != default
            ? $"* Created account {username} with ID {account.Id}"
            : $"* Account {username} could not be created.");
    }

    private void AccountDelete(TextWriter output, IReadOnlyDictionary<string, IReadOnlyList<string>> parameters)
    {
        output.WriteLine("* Not implemented");
    }
}