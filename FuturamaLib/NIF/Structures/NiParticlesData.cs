using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiParticlesData : NiGeometryData
    {
        public float ParticleRadius;

        public ushort NumActive;

        public bool HasSizes;

        public float[] Sizes;

        public NiParticlesData(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            ParticleRadius = reader.ReadSingle();
            NumActive = reader.ReadUInt16();
            HasSizes = reader.ReadBoolean();

            if (HasSizes)
                Sizes = reader.ReadArray<float>((int)NumVertices);
        }
    }
}