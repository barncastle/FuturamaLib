using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiIntegersExtraData : NiExtraData
    {
        public uint[] ExtraIntData;

        public NiIntegersExtraData(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            ExtraIntData = reader.ReadArray<uint>(reader.ReadUInt32());
        }
    }
}