using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiSpecularProperty : NiProperty
    {
        public ushort Flags;

        public NiSpecularProperty(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            Flags = reader.ReadUInt16();
        }
    }
}