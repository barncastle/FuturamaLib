using FuturamaLib.NIF.Enums;
using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class ATextureRenderData : NiObject
    {
        public PixelFormat PixelFormat;

        public uint RedMask;

        public uint GreenMask;

        public uint BlueMask;

        public uint AlphaMask;

        public byte BitsPerPixel;

        public byte[] Unknown3Bytes;

        public byte[] Unknown8Bytes;

        public NiRef<NiPalette> Palette;

        public uint NumMipMaps;

        public uint BytesPerPixel;

        public MipMap[] MipMaps;

        public ATextureRenderData(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            PixelFormat = (PixelFormat)reader.ReadUInt32();
            RedMask = reader.ReadUInt32();
            GreenMask = reader.ReadUInt32();
            BlueMask = reader.ReadUInt32();
            AlphaMask = reader.ReadUInt32();
            BitsPerPixel = reader.ReadByte();
            Unknown3Bytes = reader.ReadBytes(3);
            Unknown8Bytes = reader.ReadBytes(8);
            Palette = new NiRef<NiPalette>(reader);
            NumMipMaps = reader.ReadUInt32();
            BytesPerPixel = reader.ReadUInt32();
            MipMaps = reader.ReadArray<MipMap>(NumMipMaps);
        }
    }
}