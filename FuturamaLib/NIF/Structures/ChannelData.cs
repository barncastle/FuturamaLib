using FuturamaLib.NIF.Enums;
using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class ChannelData
    {
        public ChannelType Type;

        public ChannelConvention Convention;

        public byte BitsPerChannel;

        public byte UnknownByte;

        public ChannelData(BinaryReader reader)
        {
            Type = (ChannelType)reader.ReadUInt32();
            Convention = (ChannelConvention)reader.ReadUInt32();
            BitsPerChannel = reader.ReadByte();
            UnknownByte = reader.ReadByte();
        }
    }
}