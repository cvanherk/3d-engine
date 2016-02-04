using System;

namespace serverEngine.Net
{
    [AttributeUsage(AttributeTargets.Class)]
    class PacketAttribute : Attribute
    {
        public PacketId PacketId { get; set; }

        public PacketAttribute(PacketId id)
        {
            PacketId = id;
        }
    }
}
