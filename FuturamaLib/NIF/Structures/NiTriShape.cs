using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiTriShape : NiTriBasedGeometry
    {
        public NiTriShape(NIFReader file, BinaryReader reader) : base(file, reader)
        {
        }
    }
}