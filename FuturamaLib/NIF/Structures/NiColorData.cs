using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiColorData : NiObject
    {
        public KeyGroup<Color4Key> Data;

        public NiColorData(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            Data = new KeyGroup<Color4Key>(reader);
        }
    }
}