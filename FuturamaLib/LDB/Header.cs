namespace FuturamaLib.LDB
{
    public struct Header
    {
        public readonly uint Magic;
        public readonly int NumEntries;
        public readonly int EntryTableOffset;
        public readonly int EntryTableSize;
    }
}