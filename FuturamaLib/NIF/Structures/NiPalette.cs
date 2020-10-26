using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiPalette : NiObject
    {
        public byte UnknownByte;

        public Color4[] Palette;

        public NiPalette(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            UnknownByte = reader.ReadByte();

            Palette = new Color4[reader.ReadUInt32()];
            for (var i = 0; i < Palette.Length; i++)
                Palette[i] = reader.ReadColor4Byte();
        }
    }
}