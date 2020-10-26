using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiStringsExtraData : NiExtraData
    {
        public NiString[] ExtraStringData;

        public NiStringsExtraData(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            ExtraStringData = new NiString[reader.ReadUInt32()];
            for (var i = 0; i < ExtraStringData.Length; i++)
                ExtraStringData[i] = new NiString(reader);
        }
    }
}