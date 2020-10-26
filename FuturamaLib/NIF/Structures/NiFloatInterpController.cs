using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiFloatInterpController : NiSingleInterpController
    {
        public NiFloatInterpController(NIFReader file, BinaryReader reader) : base(file, reader)
        {
        }
    }
}