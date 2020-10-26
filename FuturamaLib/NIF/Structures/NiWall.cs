using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiWall : NiNode
    {
        public NiPlane Plane;

        public NiWall(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            Plane = new NiPlane(reader);
        }
    }
}