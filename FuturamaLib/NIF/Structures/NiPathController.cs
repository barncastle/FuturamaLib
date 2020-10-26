using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiPathController : NiTimeController
    {
        public uint Unknown2;

        public float Unknown3;

        public float Unknown4;

        public ushort Unknown5;

        public NiRef<NiPosData> PosData;

        public NiRef<NiFloatData> FloatData;

        public NiPathController(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            Unknown2 = reader.ReadUInt32();
            Unknown3 = reader.ReadSingle();
            Unknown4 = reader.ReadSingle();
            Unknown5 = reader.ReadUInt16();
            PosData = new NiRef<NiPosData>(reader);
            FloatData = new NiRef<NiFloatData>(reader);
        }
    }
}