using serverEngine.Connections;

namespace serverEngine.Net
{
    interface PacketHandler
    {
        void HandlePacket(Connection connection, Packet packet);
    }
}
