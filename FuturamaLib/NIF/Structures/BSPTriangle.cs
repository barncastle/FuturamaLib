namespace FuturamaLib.NIF.Structures
{
    public struct BSPTriangle
    {
        public float UnknownFloat; // distance? surface area?
        public uint VectorIndex1; // index into Vectors
        public uint VectorIndex2;
        public uint VectorIndex3;
        public ushort Unknown4; // probably entry offset
        public ushort Unknown5; // probably entry count
    }
}