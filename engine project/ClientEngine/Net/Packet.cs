namespace clientEngine.Net
{
    class Packet
    {
        public PacketId Id = PacketId.Invalid;
        public byte[] Data = new byte[1000];

        public Packet()
        {

        }

        public Packet(PacketId id)
        {
            Id = id;
        }

        public Packet(PacketId id,byte[] bytes)
        {
            Id = id;
            Data = bytes;
        }
    }
}
