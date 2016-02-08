using ClientEngine;
using System;

namespace clientEngine.Net.Handlers
{
    [Packet(PacketId.Position)]
    class PositionHandler : PacketHandler
    {
        public void HandlePacket(Game connection, Packet packet)
        {
            var packetBuilderGet = new PacketBuilder(packet);

            Console.WriteLine("packet postion : " + packetBuilderGet.ReadInt32());

            var p = new Packet(PacketId.Position);
            var packetBuilder = new PacketBuilder(p);

            packetBuilder.WriteInt32(12);

            p = packetBuilder.ToPacket();

           connection.Connection.SendPacket(p);
        }
    }
}
