using System;
using System.Linq;
using System.Text;
using MangosSharp.Data.Context;
using MangosSharp.Data.Entities.ClientDatabase;
using MangosSharp.Server.Core.Enums;
using Microsoft.Extensions.Logging;

namespace MangosSharp.Server.Core.Services;

public class Facts : IFacts
{
    private readonly IDatabase _database;
    private readonly ILogger _logger;

    public Facts(IDatabase database, ILogger logger)
    {
        _database = database;
        _logger = logger;
    }

    public Team GetTeamForRace(int race)
    {
        var entry = _database.UseClient(db => db.CharacterRaces.FirstOrDefault(x => x.Id == race));
        if (entry == default)
        {
            _logger.LogError("Race {} not found in DBC: wrong DBC files? ", race);
            return Team.ALLIANCE;
        }

        switch (entry.BaseLanguage)
        {
            case 7:
                return Team.ALLIANCE;
            case 1:
                return Team.HORDE;
        }

        _logger.LogError("Race {} have wrong teamid {} in DBC: wrong DBC files? ", race, entry.BaseLanguage);
        return Team.NONE;
    }

    private CharacterSection GetCharSectionEntry(byte race, CharSectionType genType, byte gender, byte type, byte color)
    {
        // TODO!
        throw new NotImplementedException();
    }

    public bool ValidateAppearance(byte race, byte klass, byte gender, byte hairStyle, byte hairColor, byte face, byte facialHair,
        byte skin)
    {
        // TODO!
        return true;
    }

    public string NormalizePlayerName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return default;

        var first = (name.Length < 1) ? string.Empty : name[..1].ToUpper();
        var rest = (name.Length < 2) ? string.Empty : name[1..].ToLower();
        return string.Concat(first, rest);
    }

    public ResponseCode CheckPlayerName(string name)
    {
        var length = Encoding.UTF8.GetByteCount(name);
        if (length > 12)
            return ResponseCode.CHAR_NAME_TOO_LONG;
        if (length < 2)
            return ResponseCode.CHAR_NAME_TOO_SHORT;
        
        // TODO: check character sets so that mixed ones are not used in the same name

        return ResponseCode.CHAR_NAME_SUCCESS;
    }

    public bool IsReservedName(ClassicmangosDbContext db, string name)
    {
        return db.ReservedNames.Any(x => x.Name == name);
    }
}

public interface IFacts
{
    Team GetTeamForRace(int race);

    bool ValidateAppearance(byte race, byte klass, byte gender, byte hairStyle, byte hairColor, byte face,
        byte facialHair, byte skin);

    string NormalizePlayerName(string name);
    ResponseCode CheckPlayerName(string name);
    bool IsReservedName(ClassicmangosDbContext db, string name);
}