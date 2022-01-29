using System;
using System.Threading.Tasks;

namespace Mangos.Server.Core;

public interface ISocketEgress
{
    string LocalEndPoint { get; }
    string RemoteEndPoint { get; }
    Task<int> Send(ReadOnlyMemory<byte> buffer);
    Task Close();
}