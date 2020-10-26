using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiParticleGrowFade : NiParticleModifier
    {
        public float Grow;

        public float Fade;

        public NiParticleGrowFade(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            Grow = reader.ReadSingle();
            Fade = reader.ReadSingle();
        }
    }
}