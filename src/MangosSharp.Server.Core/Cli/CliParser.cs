using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MangosSharp.Server.Core.Cli;

public sealed class CliParser : ICliParser
{
    public void Parse(TextWriter output, string line, IReadOnlyDictionary<string, CliCommand> commands)
    {
        Parse(output, GetFragments(line), 0, commands);
    }

    private void Parse(TextWriter output, IReadOnlyList<string> fragments, int index,
        IReadOnlyDictionary<string, CliCommand> commands)
    {
        // Has the user entered enough fragments for the command(s) chosen?
        if (fragments.Count <= index)
        {
            if (commands is { Count: > 0 })
            {
                // No, so show the list of subcommands available for the user.
                output.WriteLine();
                if (index == 0)
                    output.WriteLine("* The following commands are available:");
                else
                    output.WriteLine(
                        $"* The following subcommands are available for \"{string.Join(" ", fragments.Take(index))}\":");
                output.WriteLine($"  {string.Join(" ", commands.Keys)}");
                output.WriteLine();
                return;
            }
        }

        var fragment = fragments[index];
        foreach (var (commandName, commandData) in commands)
        {
            // Do we have a match?
            if (!commandName.Equals(fragment, StringComparison.InvariantCultureIgnoreCase))
                continue;

            // Has the user entered a command that has subcommands?
            if (commandData.Commands is { Count: > 0 })
            {
                Parse(output, fragments, index + 1, commandData.Commands);
                return;
            }

            // Has the user entered a command that has parameters?
            if (commandData.Parameters is { Count: > 0 })
            {
                // Do we have enough non-optional parameters specified?
                if (fragments.Count - index - 1 >=
                    commandData.Parameters.TakeWhile(p => p.Value.Optional == false).Count())
                {
                    IReadOnlyDictionary<string, IReadOnlyList<string>> paramList =
                        GetParameters(fragments, index + 1, commandData.Parameters, commandData.RepeatLastParameter)
                            .GroupBy(p => p.Key.ToLowerInvariant())
                            .ToDictionary(g => g.Key, g => (IReadOnlyList<string>)g.Select(kv => kv.Value).ToList());
                    commandData.Execute(output, paramList);
                    return;
                }

                // No, so tell the user how this works.
                output.WriteLine();
                output.WriteLine($"* Usage:");
                output.WriteLine(
                    $"*   {string.Join(" ", fragments.Take(index + 1))} {GetParameterUsage(commandData.Parameters, commandData.RepeatLastParameter)}");
                foreach (var (key, value) in commandData.Parameters)
                    output.WriteLine($"*   <{key}> - {value.Description}");
                output.WriteLine();
                return;
            }

            // Looks like a command that requires no further input, so execute it.
            commandData.Execute(output, new Dictionary<string, IReadOnlyList<string>>());
            return;
        }

        // No match to this point, tell the user we can't do anything about it.
        output.WriteLine();
        output.WriteLine(index == 0
            ? "* No such command."
            : $"* No such subcommand for \"{string.Join(" ", fragments.Take(index))}\".");
        output.WriteLine();
    }

    private static string GetParameterUsage(
        IReadOnlyDictionary<string, CliParameter> commandDataParameters,
        bool repeatLast)
    {
        var suffix = new StringBuilder();
        var usage = new StringBuilder();
        foreach (var (key, value) in commandDataParameters)
        {
            if (usage.Length > 0)
                usage.Append(' ');
            if (value.Optional)
            {
                usage.Append('[');
                suffix.Append(']');
            }

            usage.Append('<');
            usage.Append(key);
            usage.Append('>');
        }

        if (repeatLast && commandDataParameters.Count > 0)
            usage.Append(" ...");

        usage.Append(suffix);
        return usage.ToString();
    }

    private static IEnumerable<KeyValuePair<string, string>> GetParameters(IReadOnlyList<string> fragments, int index,
        IReadOnlyDictionary<string, CliParameter> parameters, bool repeatLast)
    {
        var parameterIndex = 0;
        var parameterList = parameters.ToList();
        var result = new List<KeyValuePair<string, string>>();

        foreach (var fragment in fragments.Skip(index))
        {
            var parameter = parameterList[parameterIndex];
            result.Add(new KeyValuePair<string, string>(parameter.Key, fragment));
            if (!repeatLast)
            {
                if (parameterIndex < parameterList.Count - 1)
                    parameterIndex++;
            }
            else
            {
                parameterIndex++;
                if (parameterIndex >= parameterList.Count)
                    break;
            }
        }

        return result;
    }

    private static List<string> GetFragments(string line)
    {
        var result = new List<string>();
        var fragment = new StringBuilder();
        var quote = false;
        var escape = false;

        foreach (var c in line)
        {
            if (escape)
            {
                fragment.Append(c);
                escape = false;
                continue;
            }

            if (quote && c != '\"')
            {
                fragment.Append(c);
                continue;
            }

            switch (c)
            {
                case '\"':
                    quote = !quote;
                    continue;
                case ' ':
                    if (fragment.Length > 0)
                    {
                        var fragmentToAdd = fragment.ToString().Trim();
                        if (fragmentToAdd.Length > 0)
                            result.Add(fragmentToAdd);
                        fragment.Clear();
                    }

                    continue;
                case '\\':
                    escape = true;
                    continue;
                default:
                    fragment.Append(c);
                    continue;
            }
        }

        var finalFragment = fragment.ToString().Trim();
        if (finalFragment.Length > 0)
            result.Add(finalFragment);
        return result;
    }
}