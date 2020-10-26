using System.IO;
using System.Numerics;

namespace FuturamaLib.NIF.Structures
{
    public class Particle
    {
        public Vector3 Velocity;

        public Vector3 UnknownVector;

        public float Lifetime;

        public float Lifespan;

        public float Timestamp;

        public ushort UnknownShort;

        public ushort VertexID;

        public Particle(BinaryReader reader)
        {
            Velocity = reader.Read<Vector3>();
            UnknownVector = reader.Read<Vector3>();
            Lifetime = reader.ReadSingle();
            Lifespan = reader.ReadSingle();
            Timestamp = reader.ReadSingle();
            UnknownShort = reader.ReadUInt16();
            VertexID = reader.ReadUInt16();
        }
    }
}