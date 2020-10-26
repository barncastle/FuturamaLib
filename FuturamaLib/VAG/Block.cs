using System.IO;

namespace FuturamaLib.VAG
{
    public class Block
    {
        public const int SamplesPerBlock = 28;
        public const int BytesPerBlock = SamplesPerBlock * 2;
        public const int Size = 16;

        public byte DecodingCoeff;
        public LoopFlags LoopFlags;
        public byte[] Data;

        public Block(BinaryReader reader)
        {
            DecodingCoeff = reader.ReadByte();
            LoopFlags = (LoopFlags)reader.ReadByte();
            Data = reader.ReadBytes(14);
        }

        public void Decode(ref byte[] buffer, int index, ref int[] samples)
        {
            var predictor = DecodingCoeff >> 4;
            var shift = DecodingCoeff & 0xF;
            var offset = index * BytesPerBlock;
            var pointer = 0;

            for (var i = 0; i < BytesPerBlock; i += 4)
            {
                var delta = Data[pointer++];
                var sample1 = (short)((delta & 0xF) << 12);
                var sample2 = (short)((delta & 0xF0) << 8);

                sample1 = Decode(sample1 >> shift, predictor, ref samples);
                buffer[offset + i + 0] = (byte)(sample1 & 0xFF);
                buffer[offset + i + 1] = (byte)((sample1 >> 8) & 0xFF);

                sample2 = Decode(sample2 >> shift, predictor, ref samples);
                buffer[offset + i + 2] = (byte)(sample2 & 0xFF);
                buffer[offset + i + 3] = (byte)((sample2 >> 8) & 0xFF);
            }
        }

        private static short Decode(int value, int predict, ref int[] samples)
        {
            var sample = value + ((samples[0] * PredictLookup[predict][0]) >> 6) + ((samples[1] * PredictLookup[predict][1]) >> 6);
            samples[1] = samples[0];
            samples[0] = sample;
            return (short)sample;
        }

        private static readonly int[][] PredictLookup = new int[][]
        {
            new [] { 000, 000 },
            new [] { 060, 000 },
            new [] { 115, -52 },
            new [] { 098, -55 },
            new [] { 122, -60 }
        };
    }
}