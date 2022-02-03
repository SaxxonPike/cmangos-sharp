using System.Threading;

namespace MangosSharp.Server.Realm;

public sealed class AppCancellation
{
    private readonly CancellationTokenSource _cancel;

    public AppCancellation()
    {
        _cancel = new CancellationTokenSource();
    }

    public CancellationToken Token => _cancel.Token;

    public void Cancel() => _cancel.Cancel();
}