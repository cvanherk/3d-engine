using System;
using System.Text;

namespace serverEngine.Net
{
    class PacketBuilder
    {
        private int _currentWriteOfset = 0;
        private int _currentReadOfset = 0;
        private byte[] _buffer = new byte[1000];

        private PacketId _id;

        public PacketId ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public PacketBuilder(PacketId id)
        {
            _id = id;
        }

        public PacketBuilder(Packet p)
        {
            Buffer.BlockCopy(p.Data, 0, _buffer, 0, p.Data.Length);
            _id = p.Id;
        }

        public void WriteString(String value)
        {
            _buffer[_currentWriteOfset] = (byte)value.Length;

            var bytes = new ASCIIEncoding().GetBytes(value);
            Buffer.BlockCopy(bytes, 0, _buffer, _currentWriteOfset + 1, bytes.Length);
            _currentWriteOfset += 1 + bytes.Length;
        }

        public string ReadString()
        {
            var length = _buffer[_currentReadOfset];
            _currentReadOfset++;
            var value = new ASCIIEncoding().GetString(_buffer, _currentReadOfset, length);
            _currentReadOfset += length;

            return value;
        }

        public void WriteInt32(int i)
        {
            var bytes = BitConverter.GetBytes(i);

            for (int x = 0; x < bytes.Length; x++)
            {
                _buffer[_currentWriteOfset + x] = bytes[x];
            }

            _currentWriteOfset += bytes.Length;
        }

        public int ReadInt32()
        {
            var value = BitConverter.ToInt32(_buffer, _currentReadOfset);
            _currentReadOfset += 4;
            return value;
        }

        public void WriteByte(byte i)
        {
            _buffer[_currentWriteOfset] = i;
            _currentWriteOfset++;
        }

        public byte ReadByte()
        {
            var value = _buffer[_currentReadOfset];
            _currentReadOfset++;
            return value;
        }

        public Packet ToPacket()
        {
            var packet = new Packet(_id);
            packet.Data = new byte[_currentWriteOfset];
            Buffer.BlockCopy(_buffer, 0, packet.Data, 0, _currentWriteOfset);
            return packet;
        }
    }
}
