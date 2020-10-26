using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiParticleModifier : NiObject
    {
        public NiRef<NiParticleModifier> Next;

        public NiRef<NiParticleSystemController> Controller;

        public NiParticleModifier(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            Next = new NiRef<NiParticleModifier>(reader);
            Controller = new NiRef<NiParticleSystemController>(reader);
        }
    }
}