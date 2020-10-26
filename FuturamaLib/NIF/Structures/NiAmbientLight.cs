using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiAmbientLight : NiLight
    {
        public NiAmbientLight(NIFReader file, BinaryReader reader) : base(file, reader)
        {
        }
    }
}