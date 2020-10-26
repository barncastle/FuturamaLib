using System;
using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class BSPNode
    {
        public uint Type; // 0-2 are nodes, 3 are leaves
        public BoundingBox Bounds;
        public float Unknown1; // axis?
        public uint[] TriangleOffsets; // BSPTriangle file offsets relative to the start of the BSPTriangle data

        public BSPNode(BinaryReader reader)
        {
            Type = reader.ReadUInt32();
            Bounds = reader.Read<BoundingBox>();

            if (Type != 3)
            {
                Unknown1 = reader.ReadSingle();
                TriangleOffsets = Array.Empty<uint>();
            }
            else
            {
                TriangleOffsets = reader.ReadArray<uint>(reader.ReadInt32());
            }
        }
    }
}