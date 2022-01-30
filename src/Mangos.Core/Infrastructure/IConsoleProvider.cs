using System.IO;

namespace Mangos.Core.Infrastructure;

public interface IConsoleProvider
{
    TextReader In { get; }
    TextWriter Out { get; }
}