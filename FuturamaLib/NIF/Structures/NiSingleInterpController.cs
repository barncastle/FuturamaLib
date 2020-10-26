using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiSingleInterpController : NiInterpController
    {
        public NiSingleInterpController(NIFReader file, BinaryReader reader) : base(file, reader)
        {
        }
    }
}