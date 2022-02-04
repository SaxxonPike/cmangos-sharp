using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MangosSharp.Core.Config;

public sealed class CommandLine : ICommandLine
{
    public CommandLine(IEnumerable<string> args)
    {
        var result = new List<KeyValuePair<string, string>>();
        var fragment = new StringBuilder();
        var currentArg = string.Empty;
        var isValue = false;
        var forceValue = false;

        foreach (var arg in args)
        {
            isValue |= forceValue;

            if (!isValue)
            {
                switch (arg)
                {
                    case "-":
                        // keep this one as-is, client will have to figure out how to utilize stdin
                        result.Add(new KeyValuePair<string, string>(string.Empty, arg));
                        continue;
                    case "--":
                        forceValue = true;
                        currentArg = string.Empty;
                        continue;
                }

                if (arg.StartsWith("--"))
                {
                    if (arg.Contains('='))
                    {
                        currentArg = arg.Substring(2, arg.IndexOf('=') - 2);
                        result.Add(new KeyValuePair<string, string>(currentArg, arg[(arg.IndexOf('=') + 1)..]));
                        currentArg = string.Empty;
                        continue;
                    }

                    currentArg = arg[2..];
                    isValue = true;
                    continue;
                }

                if (arg.StartsWith('-'))
                {
                    currentArg = arg.Substring(1, 1);
                    if (arg.Length > 2)
                    {
                        result.Add(new KeyValuePair<string, string>(currentArg, arg[2..]));
                        currentArg = string.Empty;
                        continue;
                    }

                    isValue = true;
                    continue;
                }

                result.Add(new KeyValuePair<string, string>(string.Empty, arg));
                continue;
            }

            result.Add(new KeyValuePair<string, string>(currentArg, arg));
            currentArg = string.Empty;
            isValue = false;
        }

        Args = result
            .GroupBy(g => g.Key)
            .ToDictionary(g => g.Key, g => (IReadOnlyList<string>)g.Select(kv => kv.Value).ToList());
    }

    public IReadOnlyDictionary<string, IReadOnlyList<string>> Args { get; }
}