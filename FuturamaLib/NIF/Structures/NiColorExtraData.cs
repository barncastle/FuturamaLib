using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiColorExtraData : NiExtraData
    {
        public Color4 Data;

        public NiColorExtraData(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            Data = reader.Read<Color4>();
        }
    }
}