using clientEngine.Net;
using ClientEngine;

namespace serverEngine.Net.Handlers
{
    [Packet(PacketId.Invalid)]
    class InvalidHandler : PacketHandler
    {
        public void HandlePacket(Game connection, Packet packet)
        {
            
        }
    }
}
