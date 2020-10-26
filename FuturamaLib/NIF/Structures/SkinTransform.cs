using System.IO;
using System.Numerics;
using Matrix = System.Numerics.Matrix4x4;

namespace FuturamaLib.NIF.Structures
{
    public class SkinTransform
    {
        public Matrix Rotation;

        public Vector3 Translation;

        public float Scale;

        public SkinTransform(BinaryReader reader)
        {
            Rotation = reader.ReadMatrix33();
            Translation = reader.Read<Vector3>();
            Scale = reader.ReadSingle();
        }
    }
}