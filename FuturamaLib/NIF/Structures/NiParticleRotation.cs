using System.IO;
using System.Numerics;

namespace FuturamaLib.NIF.Structures
{
    public class NiParticleRotation : NiParticleModifier
    {
        public bool RandomInitalAxis;

        public Vector3 InitialAxis;

        public float Speed;

        public NiParticleRotation(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            RandomInitalAxis = reader.ReadBoolean();
            InitialAxis = reader.Read<Vector3>();
            Speed = reader.ReadSingle();
        }
    }
}