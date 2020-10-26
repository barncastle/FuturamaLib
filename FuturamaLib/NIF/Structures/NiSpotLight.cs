using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiSpotLight : NiPointLight
    {
        public float CutoffAngle;

        public float Exponent;

        public NiSpotLight(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            CutoffAngle = reader.ReadSingle();
            Exponent = reader.ReadSingle();
        }
    }
}