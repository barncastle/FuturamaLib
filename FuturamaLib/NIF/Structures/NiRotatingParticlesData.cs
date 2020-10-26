using System.IO;
using System.Numerics;

namespace FuturamaLib.NIF.Structures
{
    public class NiRotatingParticlesData : NiParticlesData
    {
        public bool HasRotations2;

        public Vector4[] Rotations2;

        public NiRotatingParticlesData(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            HasRotations2 = reader.ReadBoolean();
            Rotations2 = reader.ReadArray<Vector4>(NumVertices);
        }
    }
}