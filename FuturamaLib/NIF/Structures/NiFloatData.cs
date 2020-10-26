using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiFloatData : NiObject
    {
        public KeyGroup<FloatKey> Data;

        public NiFloatData(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            Data = new KeyGroup<FloatKey>(reader);
        }
    }
}