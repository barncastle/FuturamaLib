using FuturamaLib.NIF.Enums;
using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiPixelData : ATextureRenderData
    {
        public uint NumPixels;

        public uint NumFaces;

        public byte[] PixelData;

        public uint Unknown;

        public NiPixelData(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            NumPixels = reader.ReadUInt32();
            PixelData = reader.ReadBytes((int)NumPixels);

            if (Version >= NifVersion.VER_4_2_1_1)
                Unknown = reader.ReadUInt32();
        }
    }
}