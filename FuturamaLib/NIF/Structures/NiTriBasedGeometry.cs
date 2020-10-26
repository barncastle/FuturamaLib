using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiTriBasedGeometry : NiGeometry
    {
        public NiTriBasedGeometry(NIFReader file, BinaryReader reader) : base(file, reader)
        {
        }
    }
}