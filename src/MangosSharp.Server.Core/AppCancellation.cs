using System.Threading;

namespace MangosSharp.Server.Core;

public sealed class AppCancellation : IAppCancellation
{
    private readonly CancellationTokenSource _cancel;

    public AppCancellation()
    {
        _cancel = new CancellationTokenSource();
    }

    public CancellationToken Token => _cancel.Token;

    public void Cancel() => _cancel.Cancel();
}