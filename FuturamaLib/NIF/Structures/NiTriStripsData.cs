using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiTriStripsData : NiTriBasedGeomData
    {
        public ushort[][] Points;

        public NiTriStripsData(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            var array = reader.ReadArray<ushort>(reader.ReadUInt16());

            Points = new ushort[array.Length][];
            for (var i = 0; i < array.Length; i++)
                Points[i] = reader.ReadArray<ushort>(array[i]);
        }
    }
}