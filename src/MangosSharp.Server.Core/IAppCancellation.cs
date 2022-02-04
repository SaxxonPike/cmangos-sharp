using System.Threading;

namespace MangosSharp.Server.Core;

public interface IAppCancellation
{
    public CancellationToken Token { get; }
    public void Cancel();
}