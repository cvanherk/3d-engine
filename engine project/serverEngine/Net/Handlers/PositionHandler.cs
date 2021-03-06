﻿using System;
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
            var packetBuilderGet = new PacketBuilder(packet);

            Console.WriteLine("packet postion : " + packetBuilderGet.ReadInt32());

            var p = new Packet(PacketId.Position);
            var packetBuilder = new PacketBuilder(p);

            packetBuilder.WriteInt32(12);

            p = packetBuilder.ToPacket();

            connection.SendPacket(p);
        }
    }
}
