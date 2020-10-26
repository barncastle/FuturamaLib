using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiFlipController : NiTimeController
    {
        public uint TextureSlot;
        public float Delta;
        public uint Unknown;
        public NiRef<NiSourceTexture>[] Textures;

        public NiFlipController(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            TextureSlot = reader.ReadUInt32();
            Delta = reader.ReadSingle();
            Unknown = reader.ReadUInt32();

            Textures = new NiRef<NiSourceTexture>[reader.ReadInt32()];
            for (var i = 0; i < Textures.Length; i++)
                Textures[i] = new NiRef<NiSourceTexture>(reader);
        }
    }
}