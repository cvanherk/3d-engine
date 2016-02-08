using System;
using System.Collections.Generic;
using System.Net.Sockets;
using serverEngine.Net;
using serverEngine.Players;

namespace serverEngine.Connections
{
    class Connection
    {
        public byte[] buffer;
        public Socket socket;
        public Queue<Packet> queuedPackets;
        public List<Byte> ChuckedRawPacket;
        
        public bool IsConnected;

        public Player Player;

        public Connection()
        {
            queuedPackets = new Queue<Packet>();
            ChuckedRawPacket = new List<Byte>();
            IsConnected = false;
        }

        public void PacketDecoder()
        {
            if (ChuckedRawPacket.Count > 0)
            {
                Packet p = new Packet();

                int packetsize = ChuckedRawPacket[1];

                lock (this)
                {
                    ChuckedRawPacket.TrimExcess();

                    p.Id = (PacketId)ChuckedRawPacket[0];
                    p.Data = ChuckedRawPacket.GetRange(2, packetsize - 2).ToArray();

                    ChuckedRawPacket.RemoveRange(0, packetsize);
                }

                queuedPackets.Enqueue(p);
                PacketDecoder();
            }
        }

        public void ProcessPackets()
        {
            lock (queuedPackets)
            {
                if (queuedPackets.Count == 0)
                    return;

                try
                {
                    Packet packet = null;

                    while (queuedPackets.Count > 0)
                    {
                        packet = queuedPackets.Dequeue();

                        if (packet != null)
                        {
                            PacketHandlers.HandlePacket(packet, this);
                        }
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("ProcessPackets: " + ex.Message);
                }
            }
        }

        public void AppendChuckedPackets(int amountOfBytes)
        {
            var chuckedPacket = new byte[amountOfBytes];
            Buffer.BlockCopy(buffer, 0, chuckedPacket, 0, amountOfBytes);
            ChuckedRawPacket.AddRange(chuckedPacket);
        }

        public void SendPacket(Packet packet)
        {
            try
            {
                if (socket.Connected)
                {
                    lock (socket)
                    {
                        if (packet.Data == null)
                            return;

                        byte[] buffer = new byte[packet.Data.Length + 2];
                        buffer[0] = (byte)packet.Id;
                        buffer[1] = (byte)(packet.Data.Length + 2);

                        Buffer.BlockCopy(packet.Data, 0, buffer, 2, packet.Data.Length);

                        int bytesend = socket.Send(buffer);
                    }
                }
            }
            catch (Exception) { }
        }

        public void Disconect()
        {
            this.socket.Dispose();
        }
    }
}
