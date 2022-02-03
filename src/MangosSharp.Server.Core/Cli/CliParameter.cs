namespace MangosSharp.Server.Core.Cli;

public sealed class CliParameter
{
    public string Description { get; init; } = "No description available.";
    public bool Optional { get; set; } = false;
}