using System.Collections.Generic;
using System.IO;
using System.Numerics;

namespace FuturamaLib.NIF.Structures
{
    public class NiBsp : NiAVObject
    {
        public BoundingBox RootBounds;
        public BSPTriangle[] Triangles;
        public Vector3[] Vectors;
        public BSPNode[] Nodes;
        public BSPUnknown[][] UnknownGroups;
        public NiRef<NiTriBasedGeometry>[] TArray; // TriShape for Xbox 4.2.1.0, TriStrip for PS2 4.2.1.1

        public NiBsp(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            RootBounds = reader.Read<BoundingBox>();

            var triangleCount = reader.ReadInt32();
            var vectorCount = reader.ReadInt32();

            Triangles = reader.ReadArray<BSPTriangle>(triangleCount);
            Vectors = reader.ReadArray<Vector3>(vectorCount);

            ReadNodes(reader);

            UnknownGroups = new BSPUnknown[reader.ReadInt32()][];
            for (var i = 0; i < UnknownGroups.Length; i++)
                UnknownGroups[i] = reader.ReadArray<BSPUnknown>(reader.ReadInt32());

            TArray = new NiRef<NiTriBasedGeometry>[reader.ReadInt32()];
            for (var i = 0; i < TArray.Length; i++)
                TArray[i] = new NiRef<NiTriBasedGeometry>(reader);
        }

        private void ReadNodes(BinaryReader reader)
        {
            // the format reads until all leaves (type 3) have been read
            // this is just an arbitary capacity
            var nodes = new List<BSPNode>(Triangles.Length / 3);

            var i = 1; // root node
            while (i > 0)
            {
                var node = new BSPNode(reader);
                nodes.Add(node);

                // increment if node else decrement if leaf
                i += node.Type < 3 ? 1 : -1;
            }

            Nodes = nodes.ToArray();
        }
    }
}