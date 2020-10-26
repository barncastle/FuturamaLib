using FuturamaLib.NIF.Enums;
using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiSourceTexture : NiTexture
    {
        public bool UseExternal;

        public NiString FileName;

        public PixelLayout PixelLayout;

        public MipMapFormat UseMipmaps;

        public AlphaFormat AlphaFormat;

        public bool IsStatic;

        public uint Unknown;

        public NiRef<ATextureRenderData> InternalTexture;

        public NiSourceTexture(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            IsStatic = true;
            UseExternal = reader.ReadBoolean();
            if (UseExternal)
            {
                FileName = new NiString(reader);
            }
            if (!UseExternal)
            {
                reader.ReadByte();
                InternalTexture = new NiRef<ATextureRenderData>(reader);
            }
            PixelLayout = (PixelLayout)reader.ReadUInt32();
            UseMipmaps = (MipMapFormat)reader.ReadUInt32();
            AlphaFormat = (AlphaFormat)reader.ReadUInt32();
            IsStatic = reader.ReadBoolean();
            Unknown = reader.ReadUInt32();
        }
    }
}