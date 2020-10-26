using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiLightColorController : NiPoint3InterpController
    {
        public NiLightColorController(NIFReader file, BinaryReader reader) : base(file, reader)
        {
        }
    }
}