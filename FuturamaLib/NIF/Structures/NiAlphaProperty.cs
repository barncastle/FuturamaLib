using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiAlphaProperty : NiProperty
    {
        public ushort Flags;

        public byte Threshold;

        public NiAlphaProperty(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            Flags = reader.ReadUInt16();
            Threshold = reader.ReadByte();
        }
    }
}