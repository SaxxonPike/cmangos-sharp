using System.Linq;
using Mangos.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Mangos.Server.World;

public class App
{
    public void Run(string[] args)
    {
        var options = new DbContextOptionsBuilder();
        options.UseMySQL("Data Source=127.0.0.1; Initial Catalog=classicmangos; User id=mangos; Password=mangos");
        var db = new MangosDbContext(options.Options);
        var quests = db.QuestTemplates.ToList();
    }
}