using Common.Extensions;
using System.IO;

namespace FuturamaLib.VAG
{
    public class Header
    {
        public readonly uint Magic;
        public readonly uint Version;
        public readonly uint DataSize;
        public readonly uint SampleRate;
        public readonly byte Channels;
        public readonly string Name;

        public uint ByteRate => SampleRate * Channels * 2;
        public int BlockCount => (int)DataSize / Block.Size;

        public Header(BinaryReader reader)
        {
            Magic = reader.ReadUInt32();
            Version = reader.ReadUInt32BE();
            reader.BaseStream.Position += 4; // reserved

            DataSize = reader.ReadUInt32BE();
            SampleRate = reader.ReadUInt32BE();
            reader.BaseStream.Position += 0xA; // reserved

            Channels = (Channels = reader.ReadByte()) == 0 ? 1 : Channels;
            reader.BaseStream.Position += 1; // reserved

            Name = new string(reader.ReadChars(0x10)).Trim();
        }
    }
}