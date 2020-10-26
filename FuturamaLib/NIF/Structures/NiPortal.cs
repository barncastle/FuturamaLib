using System.IO;
using System.Numerics;

namespace FuturamaLib.NIF.Structures
{
    public class NiPortal : NiAVObject
    {
        public Vector3[] Vertices;
        public NiRef<NiNode> Adjoiner;

        public NiPortal(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            Flags = reader.ReadUInt16();
            Vertices = reader.ReadArray<Vector3>(reader.ReadUInt16());
            Adjoiner = new NiRef<NiNode>(reader);
        }
    }
}