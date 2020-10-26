using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiStringExtraData : NiExtraData
    {
        public uint BytesRemaining;

        public NiString StringData;

        public NiStringExtraData(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            BytesRemaining = reader.ReadUInt32();
            StringData = new NiString(reader);
        }
    }
}