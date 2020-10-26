using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiFloatExtraData : NiExtraData
    {
        public float Data;

        public NiFloatExtraData(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            Data = reader.ReadSingle();
        }
    }
}