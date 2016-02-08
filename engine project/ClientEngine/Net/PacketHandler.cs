using ClientEngine;

namespace clientEngine.Net
{
    interface PacketHandler
    {
        void HandlePacket(Game connection, Packet packet);
    }
}
