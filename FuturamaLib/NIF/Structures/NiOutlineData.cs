using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiOutlineData : NiObject
    {
        public uint EdgeCount;
        public uint TrisCount;
        public uint VerticesCount;

        public ushort[][] Edges;
        public ushort[][] Tris;

        public uint[] VerticesGroups;
        public ushort[][] Vertices;

        public NiOutlineData(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            EdgeCount = reader.ReadUInt32();
            TrisCount = reader.ReadUInt32();
            VerticesCount = reader.ReadUInt32();

            Edges = new ushort[EdgeCount][];
            for (var i = 0; i < EdgeCount; i++)
                Edges[i] = reader.ReadArray<ushort>(4);

            Tris = new ushort[TrisCount][];
            for (var i = 0; i < TrisCount; i++)
                Tris[i] = reader.ReadArray<ushort>(7);

            VerticesGroups = reader.ReadArray<uint>((int)VerticesCount);

            Vertices = new ushort[VerticesCount][];
            for (var i = 0; i < VerticesCount; i++)
                Vertices[i] = reader.ReadArray<ushort>((int)VerticesGroups[i]);
        }
    }
}