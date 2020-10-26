using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiParticleMeshesData : NiRotatingParticlesData
    {
        public NiRef<NiAVObject> UnknownLink;

        public NiParticleMeshesData(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            UnknownLink = new NiRef<NiAVObject>(reader);
        }
    }
}