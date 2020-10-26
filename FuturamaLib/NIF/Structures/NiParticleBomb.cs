using FuturamaLib.NIF.Enums;
using System.IO;
using System.Numerics;

namespace FuturamaLib.NIF.Structures
{
    public class NiParticleBomb : NiParticleModifier
    {
        public float Decay;

        public float Duration;

        public float DeltaV;

        public float Start;

        public DecayType DecayType;

        public SymmetryType SymmetryType;

        public Vector3 Position;

        public Vector3 Direction;

        public NiParticleBomb(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            Decay = reader.ReadSingle();
            Duration = reader.ReadSingle();
            DeltaV = reader.ReadSingle();
            Start = reader.ReadSingle();
            DecayType = (DecayType)reader.ReadUInt32();
            SymmetryType = (SymmetryType)reader.ReadUInt32();
            Position = reader.Read<Vector3>();
            Direction = reader.Read<Vector3>();
        }
    }
}