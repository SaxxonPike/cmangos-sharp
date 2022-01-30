using System;
using System.Threading.Tasks;

namespace Mangos.Server.Core.Sockets;

public interface ISocketIngress
{
    int Available { get; }
    string LocalEndPoint { get; }
    string RemoteEndPoint { get; }
    Task<int> Receive(Memory<byte> bytes);
    Task Close();
}