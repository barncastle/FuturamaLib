using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiWireframeProperty : NiProperty
    {
        public ushort Flags;

        public NiWireframeProperty(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            Flags = reader.ReadUInt16();
        }
    }
}