using ClientEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace clientEngine.Net
{
    class PacketHandlers
    {
        public static readonly Dictionary<PacketId, PacketHandler> handlers = new Dictionary<PacketId, PacketHandler>();

        static PacketHandlers()
        {

            var handlerTypes = GetTypesWithAttribute<PacketAttribute>();

            foreach (var handler in handlerTypes)
            {
                var att = (PacketAttribute)handler.GetCustomAttribute(typeof(PacketAttribute));
                var instance = (PacketHandler)Activator.CreateInstance(handler);
                handlers[att.PacketId] = instance;
            }
        }

        public static void HandlePacket(Packet p, Game con)
        {
            PacketHandler handler = null;

            if (handlers.TryGetValue(p.Id, out handler))
            {
                handler.HandlePacket(con, p);
            }
        }

        public static IEnumerable<Type> GetTypesWithAttribute<T>(Assembly assembly = null)
        {
            if (assembly == null)
                assembly = Assembly.GetExecutingAssembly();
            return assembly.GetTypes().Where(type => type.GetCustomAttributes(typeof(T), true).Length > 0);
        }
    }

    public enum PacketId
    {
        Invalid = 0,
        Login = 1,
        Position = 2,
    }
}
