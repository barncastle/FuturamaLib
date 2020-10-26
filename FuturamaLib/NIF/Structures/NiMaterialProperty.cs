using System.IO;
using Color3 = FuturamaLib.NIF.Structures.Color4;

namespace FuturamaLib.NIF.Structures
{
    public class NiMaterialProperty : NiProperty
    {
        public ushort Flags;

        public Color3 AmbientColor;

        public Color3 DiffuseColor;

        public Color3 SpecularColor;

        public Color3 EmissiveColor;

        public float Glossiness;

        public float Alpha;

        public NiMaterialProperty(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            Flags = reader.ReadUInt16();
            AmbientColor = reader.ReadColor3();
            DiffuseColor = reader.ReadColor3();
            SpecularColor = reader.ReadColor3();
            EmissiveColor = reader.ReadColor3();
            Glossiness = reader.ReadSingle();
            Alpha = reader.ReadSingle();
        }
    }
}