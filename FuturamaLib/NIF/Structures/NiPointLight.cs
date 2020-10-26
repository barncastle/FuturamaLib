using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiPointLight : NiLight
    {
        public float ConstantAttenuation;

        public float LinearAttenuation;

        public float QuadraticAttenuation;

        public NiPointLight(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            ConstantAttenuation = reader.ReadSingle();
            LinearAttenuation = reader.ReadSingle();
            QuadraticAttenuation = reader.ReadSingle();
        }
    }
}