using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiPosData : NiObject
    {
        public KeyGroup<VecKey> Data;

        public NiPosData(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            Data = new KeyGroup<VecKey>(reader);
        }
    }
}