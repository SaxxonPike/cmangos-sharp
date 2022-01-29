using System.Linq;
using Mangos.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Mangos.Server.World;

public class App
{
    private readonly IConfiguration _configuration;

    public App(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public void Run(string[] args)
    {
        var dbConfig = _configuration["MangosdConf.WorldDatabaseInfo"].Split(';');
        var connectionString =
            $"Data Source={dbConfig[0]}; Initial Catalog={dbConfig[4]}; User id={dbConfig[2]}; Password={dbConfig[3]}";
        var options = new DbContextOptionsBuilder();
        options.UseMySQL(connectionString);
        var db = new MangosDbContext(options.Options);
        var quests = db.QuestTemplates.ToList();
    }
}