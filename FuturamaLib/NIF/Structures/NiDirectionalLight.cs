using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiDirectionalLight : NiLight
    {
        public NiDirectionalLight(NIFReader file, BinaryReader reader) : base(file, reader)
        {
        }
    }
}