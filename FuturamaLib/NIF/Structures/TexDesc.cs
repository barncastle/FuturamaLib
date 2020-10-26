using FuturamaLib.NIF.Enums;
using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class TexDesc
    {
        public NiRef<NiSourceTexture> Source;

        public TexClampMode ClampMode;

        public TexFilterMode FilterMode;

        public uint UVSetIndex;

        public short PS2L;

        public short PS2K;

        public TexDesc(BinaryReader reader)
        {
            Source = new NiRef<NiSourceTexture>(reader);
            ClampMode = (TexClampMode)reader.ReadUInt32();
            FilterMode = (TexFilterMode)reader.ReadUInt32();
            UVSetIndex = reader.ReadUInt32();
            PS2L = reader.ReadInt16();
            PS2K = reader.ReadInt16();
        }
    }
}