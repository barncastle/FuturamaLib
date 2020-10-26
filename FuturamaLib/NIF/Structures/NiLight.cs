using System.IO;
using Color3 = FuturamaLib.NIF.Structures.Color4;

namespace FuturamaLib.NIF.Structures
{
    public class NiLight : NiDynamicEffect
    {
        public float Dimmer;

        public Color3 AmbientColor;

        public Color3 DiffuseColor;

        public Color3 SpecularColor;

        public NiLight(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            Dimmer = reader.ReadSingle();
            AmbientColor = reader.ReadColor3();
            DiffuseColor = reader.ReadColor3();
            SpecularColor = reader.ReadColor3();
        }
    }
}