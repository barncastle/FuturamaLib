using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiTriStrips : NiTriBasedGeometry
    {
        public NiTriStrips(NIFReader file, BinaryReader reader) : base(file, reader)
        {
        }
    }
}