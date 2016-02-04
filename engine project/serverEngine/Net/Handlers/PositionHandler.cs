using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using serverEngine.Connections;

namespace serverEngine.Net.Handlers
{
    [Packet(PacketId.Position)]
    class PositionHandler : PacketHandler
    {
        public void HandlePacket(Connection connection, Packet packet)
        {
            
        }
    }
}
