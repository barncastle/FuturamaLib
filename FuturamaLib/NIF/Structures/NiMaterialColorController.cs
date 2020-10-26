using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiMaterialColorController : NiPoint3InterpController
    {
        public NiMaterialColorController(NIFReader file, BinaryReader reader) : base(file, reader)
        {
        }
    }
}