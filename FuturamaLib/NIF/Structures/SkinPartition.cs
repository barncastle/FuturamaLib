using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class SkinPartition
    {
        public ushort NumVertices;

        public ushort NumTriangles;

        public ushort NumBones;

        public ushort NumStrips;

        public ushort NumWeightsPerVertex;

        public ushort[] Bones;

        public ushort[] VertexMap;

        public float[][] VertexWeights;

        public ushort[] StripLengths;

        public ushort[][] Strips;

        public Triangle[] Triangles;

        public bool HasBoneIndicies;

        public byte[][] BoneIndicies;

        public ushort UnknownShort;

        public SkinPartition(BinaryReader reader)
        {
            NumVertices = reader.ReadUInt16();
            NumTriangles = reader.ReadUInt16();
            NumBones = reader.ReadUInt16();
            NumStrips = reader.ReadUInt16();
            NumWeightsPerVertex = reader.ReadUInt16();
            Bones = reader.ReadArray<ushort>(NumBones);
            VertexMap = reader.ReadArray<ushort>(NumVertices);

            VertexWeights = new float[NumVertices][];
            for (var i = 0; i < NumVertices; i++)
                VertexWeights[i] = reader.ReadArray<float>(NumWeightsPerVertex);

            if (NumStrips == 0)
            {
                Triangles = reader.ReadArray<Triangle>(NumTriangles);
            }
            else
            {
                StripLengths = reader.ReadArray<ushort>(NumStrips);

                Strips = new ushort[NumStrips][];
                for (var i = 0; i < NumStrips; i++)
                    Strips[i] = reader.ReadArray<ushort>(StripLengths[i]);
            }

            HasBoneIndicies = reader.ReadBoolean();
            if (HasBoneIndicies)
            {
                BoneIndicies = new byte[NumVertices][];
                for (var i = 0; i < BoneIndicies.Length; i++)
                    BoneIndicies[i] = reader.ReadBytes(NumWeightsPerVertex);
            }
        }
    }
}