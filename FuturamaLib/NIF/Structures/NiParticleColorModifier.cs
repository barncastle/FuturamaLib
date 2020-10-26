using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiParticleColorModifier : NiParticleModifier
    {
        public NiRef<NiColorData> Data;

        public NiParticleColorModifier(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            Data = new NiRef<NiColorData>(reader);
        }
    }
}