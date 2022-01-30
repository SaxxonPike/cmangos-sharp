using System;
using Mangos.Data.Context;

namespace Mangos.Server.Core.Services;

public interface IDatabase
{
    void UseLogin(Action<RealmDbContext> context);
    void UseWorld(Action<MangosDbContext> context);
    void UseCharacter(Action<CharacterDbContext> context);
    void UseLogs(Action<LogsDbContext> context);
    void UseClient(Action<ClientDbContext> context);
}