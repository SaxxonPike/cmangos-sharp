using System.Collections.Generic;
using System.IO;

namespace MangosSharp.Server.Core.Cli;

public interface ICliParser
{
    void Parse(TextWriter output, string line, IReadOnlyDictionary<string, CliCommand> commands);
}