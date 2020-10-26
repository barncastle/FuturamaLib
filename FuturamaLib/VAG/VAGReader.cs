using FuturamaLib.Extensions;
using System;
using System.IO;

namespace FuturamaLib.VAG
{
    public class VAGReader
    {
        public const uint Magic = 0x70474156;

        public Header Header { get; }
        public Block[] Blocks { get; }

        public VAGReader(string filepath) : this(File.OpenRead(filepath))
        {
        }

        public VAGReader(Stream stream)
        {
            using var reader = new BinaryReader(stream);

            Header = new Header(reader);
            if (Header.Magic != Magic)
                throw new FormatException($"Invalid header. Expected {Magic:X8}, got {Header.Magic:X8}");

            Blocks = Arrays.InitWithInstance<Block>(Header.BlockCount, reader);
        }

        public byte[] DecodeSamples()
        {
            var result = new byte[Blocks.Length * Block.BytesPerBlock];
            var samples = new int[2];

            for (var i = 0; i < Blocks.Length; i++)
            {
                if (Blocks[i].LoopFlags == LoopFlags.PlaybackEnd)
                    break;

                Blocks[i].Decode(ref result, i, ref samples);

                if (Blocks[i].LoopFlags == LoopFlags.LastBlock)
                    break;
            }

            return result;
        }

        /// <summary>
        /// Exports the VAG file to WAV
        /// </summary>
        /// <param name="outputfilename"></param>
        public void Export(string outputfilename)
        {
            using var fs = File.Create(outputfilename);
            using var writer = new BinaryWriter(fs);

            var pcm = DecodeSamples();

            writer.Write(WAVEConsts.ChunkID);
            writer.Write(WAVEConsts.ChunkSize + pcm.Length);
            writer.Write(WAVEConsts.Format);
            writer.Write(WAVEConsts.SubChunkID);
            writer.Write(WAVEConsts.SubChunkSize);
            writer.Write(WAVEConsts.PCMAudioFormat);
            writer.Write((short)Header.Channels);
            writer.Write(Header.SampleRate);
            writer.Write(Header.ByteRate);
            writer.Write((short)(Header.Channels * 2)); // block align
            writer.Write(WAVEConsts.BitsPerSample);
            writer.Write(WAVEConsts.DataID);
            writer.Write(pcm.Length);
            writer.Write(pcm);
            writer.Flush();
        }
    }
}