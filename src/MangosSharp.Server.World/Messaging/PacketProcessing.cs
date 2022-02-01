namespace MangosSharp.Server.World.Messaging;

public enum PacketProcessing
{
    INPLACE = 0, // process packet whenever we receive it - mostly for non-handled or non-implemented packets
    THREADUNSAFE, // packet is not thread-safe - process it in World::UpdateSessions()
    THREADSAFE, // packet is thread-safe - process it in Map::Update()
    MAP_THREAD, // packet is map thread safe
    IMMEDIATE,
}