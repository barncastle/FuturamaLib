using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiTriShapeData : NiTriBasedGeomData
    {
        public uint NumTrianglePoints;

        public Triangle[] Triangles;

        public ushort[][] MatchGroups;

        public NiTriShapeData(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            NumTrianglePoints = reader.ReadUInt32();
            Triangles = reader.ReadArray<Triangle>(NumTriangles);

            MatchGroups = new ushort[reader.ReadUInt16()][];
            for (var i = 0; i < MatchGroups.Length; i++)
                MatchGroups[i] = reader.ReadArray<ushort>(reader.ReadUInt16());
        }
    }
}