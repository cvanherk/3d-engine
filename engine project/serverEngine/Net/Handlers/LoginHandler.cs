using System;
using serverEngine.Connections;
using serverEngine.Players;

namespace serverEngine.Net.Handlers
{
    [Packet(PacketId.Position)]
    class LoginHandler : PacketHandler
    {
        public void HandlePacket(Connection connection, Packet packet)
        {
            var playerData = new PacketBuilder(packet);

            var name = playerData.ReadString();
            var password = playerData.ReadString();


            

            var player = new Player(connection);

            //player aanmaken
            //player inladen

            //-- versturen --
            //player positie
            //player rotation
            //map init
            //name

            var packetBuilder = new PacketBuilder(PacketId.Login);

            connection.SendPacket(packetBuilder.ToPacket());
        }

        public enum LoginReturnList
        {
            Invalid,
            Unknown,
            ErrorCreating,
            ErrorLoading,
            ErrorGet,
            ErrorMap,
            ErrorName,
            ErrorPassword,
            Succes,
        };
    }
}
