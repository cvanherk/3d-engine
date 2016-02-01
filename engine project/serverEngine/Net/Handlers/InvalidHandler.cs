using serverEngine.Connections;

namespace serverEngine.Net.Handlers
{
    [Packet(PacketId.Invalid)]
    class InvalidHandler : PacketHandler
    {
        public void HandlePacket(Connection connection, Packet packet)
        {
            
        }
    }
}
