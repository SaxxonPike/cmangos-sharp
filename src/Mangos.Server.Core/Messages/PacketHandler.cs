using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace Mangos.Server.Core.Messages;

public delegate bool OpcodeHandler<in TOpcode, in TStream>(TOpcode opcode, TStream stream, CancellationToken cancel)
    where TStream : Stream;

public abstract class PacketHandler<TOpcode, TStream> : IPacketHandler 
    where TStream : Stream
{
    private readonly IDictionary<int, OpcodeHandler<TOpcode, TStream>> _handlers;
    private readonly IDictionary<int, TOpcode> _opcodeMap;
    private readonly int _handlerMin;
    private readonly int _handlerMax;

    protected PacketHandler()
    {
        // ReSharper disable once VirtualMemberCallInConstructor
        var handlers = GetHandlers();
        _handlers = handlers.ToDictionary(kv => (int)(object)kv.Key, kv => kv.Value);
        _opcodeMap = handlers.ToDictionary(kv => (int)(object)kv.Key, kv => kv.Key);
        if (_handlers.Count > 0)
        {
            _handlerMin = _handlers.Min(kv => kv.Key);
            _handlerMax = _handlers.Max(kv => kv.Key);
        }
        else
        {
            _handlerMin = int.MaxValue;
            _handlerMax = int.MinValue;
        }
    }

    protected abstract int ReadOpcode(TStream stream);

    protected abstract IReadOnlyDictionary<TOpcode, OpcodeHandler<TOpcode, TStream>> GetHandlers();

    public bool Handle(Stream inStream, CancellationToken cancel)
    {
        if (inStream is not TStream stream)
            return false;

        var opcode = ReadOpcode(stream);
        return opcode >= _handlerMin && 
               opcode <= _handlerMax && 
               _handlers.TryGetValue(opcode, out var handler) && 
               handler(_opcodeMap[opcode], stream, cancel);
    }
}