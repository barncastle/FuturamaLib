using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiTriBasedGeomData : NiGeometryData
    {
        public ushort NumTriangles;

        public NiTriBasedGeomData(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            NumTriangles = reader.ReadUInt16();
        }
    }
}