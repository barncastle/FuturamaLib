using System.IO;
using System.Numerics;

namespace FuturamaLib.NIF.Structures
{
    public class NiGravity : NiParticleModifier
    {
        public float UnknownFloat1;

        public float Force;

        public uint Type;

        public Vector3 Position;

        public Vector3 Direction;

        public NiGravity(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            UnknownFloat1 = reader.ReadSingle();
            Force = reader.ReadSingle();
            Type = reader.ReadUInt32();
            Position = reader.Read<Vector3>();
            Direction = reader.Read<Vector3>();
        }
    }
}