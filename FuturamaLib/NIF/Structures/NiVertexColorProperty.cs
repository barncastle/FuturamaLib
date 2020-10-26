using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiVertexColorProperty : NiProperty
    {
        public ushort Flags;

        public uint VertexMode;

        public uint LightingMode;

        public NiVertexColorProperty(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            Flags = reader.ReadUInt16();
            VertexMode = reader.ReadUInt32();
            LightingMode = reader.ReadUInt32();
        }
    }
}