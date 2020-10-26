using System.IO;
using Color3 = FuturamaLib.NIF.Structures.Color4;

namespace FuturamaLib.NIF.Structures
{
    public class NiFogProperty : NiProperty
    {
        public ushort Flags;

        public float Depth;

        public Color3 Color;

        public NiFogProperty(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            Flags = reader.ReadUInt16();
            Depth = reader.ReadSingle();
            Color = reader.ReadColor3();
        }
    }
}