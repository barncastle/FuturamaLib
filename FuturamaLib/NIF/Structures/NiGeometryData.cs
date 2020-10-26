using System.IO;
using System.Numerics;

namespace FuturamaLib.NIF.Structures
{
    public class NiGeometryData : NiObject
    {
        public bool HasVertices;

        public Vector3[] Vertices;

        public byte TSpaceFlag;

        public bool HasNormals;

        public Vector3[] Normals;

        public bool HasVertexColors;

        public Vector3 Center;

        public float Radius;

        public Color4[] VertexColors;

        public Vector2[][] UVSets;

        public uint NumVertices;

        public NiGeometryData(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            NumVertices = reader.ReadUInt16();
            HasVertices = reader.ReadBoolean();

            if (HasVertices)
                Vertices = reader.ReadArray<Vector3>(NumVertices);

            HasNormals = reader.ReadBoolean();
            if (HasNormals)
                Normals = reader.ReadArray<Vector3>(NumVertices);

            Center = reader.Read<Vector3>();
            Radius = reader.ReadSingle();

            HasVertexColors = reader.ReadBoolean();
            if (HasVertexColors)
                VertexColors = reader.ReadArray<Color4>(NumVertices);

            var numUvSets = reader.ReadByte();
            TSpaceFlag = reader.ReadByte();

            UVSets = new Vector2[numUvSets][];
            for (var i = 0; i < numUvSets; i++)
                UVSets[i] = reader.ReadArray<Vector2>(NumVertices);
        }
    }
}