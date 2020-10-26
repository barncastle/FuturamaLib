using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiZBufferProperty : NiProperty
    {
        public ushort Flags;

        public uint ZCompareMode;

        public NiZBufferProperty(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            Flags = reader.ReadUInt16();
            ZCompareMode = reader.ReadUInt32();
        }
    }
}