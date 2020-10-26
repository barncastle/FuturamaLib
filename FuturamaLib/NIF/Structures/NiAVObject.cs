using System.IO;
using System.Numerics;
using Matrix = System.Numerics.Matrix4x4;

namespace FuturamaLib.NIF.Structures
{
    public class NiAVObject : NiObjectNET
    {
        public ushort Flags;

        public Vector3 Translation;

        public Matrix Rotation;

        public float Scale;

        public Vector3 Velocity;

        public NiRef<NiProperty>[] Properties;

        public bool HasBoundingBox;

        public BoundingBox BoundingBox;

        public NiAVObject(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            Flags = reader.ReadUInt16();
            Translation = reader.Read<Vector3>();
            Rotation = reader.ReadMatrix33();
            Scale = reader.ReadSingle();
            Velocity = reader.Read<Vector3>();

            Properties = new NiRef<NiProperty>[reader.ReadUInt32()];
            for (var i = 0; i < Properties.Length; i++)
                Properties[i] = new NiRef<NiProperty>(reader.ReadUInt32());

            HasBoundingBox = reader.ReadBoolean(Version);
            if (HasBoundingBox)
                BoundingBox = reader.Read<BoundingBox>();
        }
    }
}