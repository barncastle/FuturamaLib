using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiBinaryExtraData : NiExtraData
    {
        public byte[] Data;

        public NiBinaryExtraData(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            Data = reader.ReadBytes((int)reader.ReadUInt32());
        }
    }
}