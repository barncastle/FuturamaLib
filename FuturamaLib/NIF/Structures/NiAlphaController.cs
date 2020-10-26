using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiAlphaController : NiFloatInterpController
    {
        public NiRef<NiFloatData> Data;

        public NiAlphaController(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            Data = new NiRef<NiFloatData>(reader);
        }
    }
}