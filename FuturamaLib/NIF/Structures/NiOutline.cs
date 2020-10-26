using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiOutline : NiNode
    {
        public NiRef<NiOutlineData> OutlineData;

        public NiOutline(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            OutlineData = new NiRef<NiOutlineData>(reader);
        }
    }
}