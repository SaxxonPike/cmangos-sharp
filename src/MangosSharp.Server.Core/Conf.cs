namespace MangosSharp.Server.Core;

public readonly struct Conf
{
    public Conf(string name, object fallback)
    {
        Name = name;
        Fallback = fallback;
    }

    public string Name { get; }
    public object Fallback { get; }
    
    public static readonly Conf CHARACTERS_PER_REALM = new("CharactersPerRealm", 10);
    public static readonly Conf CHARACTERS_PER_ACCOUNT = new("CharactersPerAccount", 50);
    public static readonly Conf MAX_OVERSPEED_PINGS = new("MaxOverspeedPings", 2);
    public static readonly Conf CHARACTERS_CREATING_DISABLED = new("CharactersCreatingDisabled", 0);
}