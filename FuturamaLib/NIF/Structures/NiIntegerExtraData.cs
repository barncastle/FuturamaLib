using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiIntegerExtraData : NiExtraData
    {
        public uint Data;

        public NiIntegerExtraData(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            Data = reader.ReadUInt32();
        }
    }
}