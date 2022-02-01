using System.IO;

namespace MangosSharp.Core.Infrastructure;

public interface IConsoleProvider
{
    TextReader In { get; }
    TextWriter Out { get; }
}