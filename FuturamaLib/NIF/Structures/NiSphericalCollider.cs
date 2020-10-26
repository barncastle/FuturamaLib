using FuturamaLib.NIF.Enums;
using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiSphericalCollider : NiParticleModifier
    {
        public float UnknownFloat1;

        public ushort UnknownShort1;

        public float UnknownFloat2;

        public ushort UnknownShort2;

        public float UnknownFloat3;

        public float UnknownFloat4;

        public float UnknownFloat5;

        public NiSphericalCollider(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            UnknownFloat1 = reader.ReadSingle();
            UnknownShort1 = reader.ReadUInt16();
            UnknownFloat2 = reader.ReadSingle();
            if (Version <= NifVersion.VER_4_2_0_2)
            {
                UnknownShort2 = reader.ReadUInt16();
            }
            else
            {
                UnknownFloat3 = reader.ReadSingle();
            }
            UnknownFloat4 = reader.ReadSingle();
            UnknownFloat5 = reader.ReadSingle();
        }
    }
}