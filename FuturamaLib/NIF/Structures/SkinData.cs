using System.IO;
using System.Numerics;

namespace FuturamaLib.NIF.Structures
{
    public class SkinData
    {
        public SkinTransform Transform;

        public Vector3 BoundingSphereOffset;

        public float BoundingSphereRadius;

        public ushort NumVertices;

        public SkinWeight[] VertexWeights;

        public SkinData(BinaryReader reader, bool hasVertexWeights)
        {
            Transform = new SkinTransform(reader);
            BoundingSphereOffset = reader.Read<Vector3>();
            BoundingSphereRadius = reader.ReadSingle();
            NumVertices = reader.ReadUInt16();

            if (hasVertexWeights)
            {
                VertexWeights = new SkinWeight[NumVertices];
                for (var i = 0; i < NumVertices; i++)
                    VertexWeights[i] = new SkinWeight(reader);
            }
        }
    }
}