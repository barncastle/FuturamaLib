using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiPoint3InterpController : NiSingleInterpController
    {
        public NiRef<NiPosData> Data;

        public NiPoint3InterpController(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            Data = new NiRef<NiPosData>(reader);
        }
    }
}