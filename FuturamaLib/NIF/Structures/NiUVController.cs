using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiUVController : NiTimeController
    {
        public ushort UnknownShort1;

        public NiRef<NiUVData> Data;

        public NiUVController(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            UnknownShort1 = reader.ReadUInt16();
            Data = new NiRef<NiUVData>(reader);
        }
    }
}