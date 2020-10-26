using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiVisController : NiBoolInterpController
    {
        public NiRef<NiVisData> Data;

        public NiVisController(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            Data = new NiRef<NiVisData>(reader);
        }
    }
}