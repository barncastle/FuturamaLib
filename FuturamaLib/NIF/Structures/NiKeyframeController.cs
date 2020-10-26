using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiKeyframeController : NiSingleInterpController
    {
        public NiRef<NiKeyframeData> Data;

        public NiKeyframeController(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            Data = new NiRef<NiKeyframeData>(reader);
        }
    }
}