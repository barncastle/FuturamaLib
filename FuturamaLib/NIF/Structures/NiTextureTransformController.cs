using FuturamaLib.NIF.Enums;
using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiTextureTransformController : NiFloatInterpController
    {
        public byte Unknown2;

        public TexType TextureSlot;

        public TexTransform Operation;

        public NiRef<NiFloatData> Data;

        public NiTextureTransformController(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            Unknown2 = reader.ReadByte();
            TextureSlot = (TexType)reader.ReadUInt32();
            Operation = (TexTransform)reader.ReadUInt32();
            Data = new NiRef<NiFloatData>(reader);
        }
    }
}