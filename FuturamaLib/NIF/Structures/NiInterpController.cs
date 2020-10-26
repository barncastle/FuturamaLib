using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiInterpController : NiTimeController
    {
        public NiInterpController(NIFReader file, BinaryReader reader) : base(file, reader)
        {
        }
    }
}