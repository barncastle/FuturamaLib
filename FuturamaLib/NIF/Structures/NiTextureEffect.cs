using FuturamaLib.NIF.Enums;
using System.IO;
using System.Numerics;
using Matrix = System.Numerics.Matrix4x4;

namespace FuturamaLib.NIF.Structures
{
    public class NiTextureEffect : NiDynamicEffect
    {
        public Matrix ModelProjectionMatrix;

        public Vector3 ModelProjectionTransform;

        public TexFilterMode TextureFiltering;

        public TexClampMode TextureClamping;

        public EffectType EffectType;

        public CoordGenType CoordGenType;

        public NiRef<NiSourceTexture> SourceTexture;

        public bool ClippingPlane;

        public Plane ModelPlane;

        public short PS2L;

        public short PS2K;

        public NiTextureEffect(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            ModelProjectionMatrix = reader.ReadMatrix33();
            ModelProjectionTransform = reader.Read<Vector3>();
            TextureFiltering = (TexFilterMode)reader.ReadUInt32();
            TextureClamping = (TexClampMode)reader.ReadUInt32();
            EffectType = (EffectType)reader.ReadUInt32();
            CoordGenType = (CoordGenType)reader.ReadUInt32();
            SourceTexture = new NiRef<NiSourceTexture>(reader);
            ClippingPlane = reader.ReadBoolean();
            ModelPlane = reader.Read<Plane>();
            PS2L = reader.ReadInt16();
            PS2K = reader.ReadInt16();
        }
    }
}