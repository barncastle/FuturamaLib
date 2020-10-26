using System.IO;
using System.Numerics;

namespace FuturamaLib.NIF.Structures
{
    public class NiTexturingProperty : NiProperty
    {
        public ushort Flags;

        public uint ApplyMode;

        public uint TextureCount;

        public TexDesc BaseTexture;

        public TexDesc DarkTexture;

        public TexDesc DetailTexture;

        public TexDesc GlossTexture;

        public TexDesc GlowTexture;

        public TexDesc BumpMapTexture;

        public TexDesc Decal0Texture;

        public float BumpMapLumaScale;

        public float BumpMapLumaOffset;

        public Vector3 BumpMapMatrix;

        public NiTexturingProperty(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            Flags = reader.ReadUInt16();
            ApplyMode = reader.ReadUInt32();
            TextureCount = reader.ReadUInt32();
            if (reader.ReadBoolean())
            {
                BaseTexture = new TexDesc(reader);
            }
            if (reader.ReadBoolean())
            {
                DarkTexture = new TexDesc(reader);
            }
            if (reader.ReadBoolean())
            {
                DetailTexture = new TexDesc(reader);
            }
            if (reader.ReadBoolean())
            {
                GlossTexture = new TexDesc(reader);
            }
            if (reader.ReadBoolean())
            {
                GlowTexture = new TexDesc(reader);
            }
            if (reader.ReadBoolean())
            {
                BumpMapTexture = new TexDesc(reader);
                BumpMapLumaScale = reader.ReadSingle();
                BumpMapLumaOffset = reader.ReadSingle();
                BumpMapMatrix = reader.Read<Vector3>();
                reader.ReadSingle();
            }
            if (reader.ReadBoolean())
            {
                Decal0Texture = new TexDesc(reader);
            }
        }
    }
}