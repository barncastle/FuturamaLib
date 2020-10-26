using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiDitherProperty : NiProperty
    {
        public ushort Flags;

        public NiDitherProperty(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            Flags = reader.ReadUInt16();
        }
    }
}