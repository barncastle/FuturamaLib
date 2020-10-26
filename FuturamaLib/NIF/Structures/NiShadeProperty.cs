using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiShadeProperty : NiProperty
    {
        public ushort Flags;

        public NiShadeProperty(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            Flags = reader.ReadUInt16();
        }
    }
}