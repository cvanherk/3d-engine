using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serverEngine.Net
{
    class PacketBuilder
    {
        private byte[] _data;
        private PacketId _id;
        private bool _readMode;

        private int _currentReadOfset = 0;
        private int _currentWriteOfset = 0;

        public PacketBuilder()
        {
            _readMode = false;
        }

        public PacketBuilder(Packet packet)
        {
            _data = packet.Data;
            _id = packet.Id;
            _readMode = true;
        }

        public void WriteInt32(int value)
        {
            var bytes = BitConverter.GetBytes(value);
            Buffer.BlockCopy(bytes, 0, _data, _currentWriteOfset, bytes.Length);
        }

        public int ReadInt32()
        {
            var i = BitConverter.ToInt32(_data, _currentReadOfset);
            _currentReadOfset += 4;
            return i;
        }

        public byte ReadByte()
        {
            var b = _data[_currentReadOfset];
            _currentReadOfset++;
            return b;
        }
    }
}
