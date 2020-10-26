namespace FuturamaLib.VAG
{
    public static class WAVEConsts
    {
        public static readonly char[] ChunkID = "RIFF".ToCharArray();
        public static readonly char[] Format = "WAVE".ToCharArray();
        public static readonly char[] SubChunkID = "fmt ".ToCharArray();
        public static readonly char[] DataID = "data".ToCharArray();

        public const int ChunkSize = 36;
        public const int SubChunkSize = 16;
        public const ushort PCMAudioFormat = 1;
        public const ushort BitsPerSample = 16;
    }
}