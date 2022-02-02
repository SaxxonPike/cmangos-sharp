using System.Linq;
using MangosSharp.Server.Core.Services;

namespace MangosSharp.Server.World.Conditions;

public class ConditionCompiler : IConditionCompiler
{
    private readonly IDatabase _database;

    public ConditionCompiler(IDatabase database)
    {
        _database = database;
    }
    
    public void Compile()
    {
        var conditions = _database.UseWorld(db => db.Conditions.Select(c => new
        {
            c.ConditionEntry,
            c.Type,
            c.Flags,
            c.Value1,
            c.Value2,
            c.Value3,
            c.Value4
        }).ToList());
    }

    public bool Resolve(uint id)
    {
        throw new System.NotImplementedException();
    }
}

public interface IConditionCompiler
{
    public void Compile();
    public bool Resolve(uint id);
}