using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public struct MipMap
    {
        public uint Width;

        public uint Height;

        public uint Offset;

        public MipMap(BinaryReader reader)
        {
            Width = reader.ReadUInt32();
            Height = reader.ReadUInt32();
            Offset = reader.ReadUInt32();
        }
    }
}