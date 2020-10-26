using FuturamaLib.NIF.Enums;
using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiPlanarCollider : NiParticleModifier
    {
        public float UnknownFloat1;

        public float UnknownFloat2;

        public ushort UnknownShort2;

        public float UnknownFloat3;

        public float UnknownFloat4;

        public float UnknownFloat5;

        public float UnknownFloat6;

        public float UnknownFloat7;

        public float UnknownFloat8;

        public float UnknownFloat9;

        public float UnknownFloat10;

        public float UnknownFloat11;

        public float UnknownFloat12;

        public float UnknownFloat13;

        public float UnknownFloat14;

        public float UnknownFloat15;

        public float UnknownFloat16;

        public NiPlanarCollider(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            UnknownFloat1 = reader.ReadSingle();
            UnknownFloat2 = reader.ReadSingle();
            if (Version == NifVersion.VER_4_2_2_0)
            {
                UnknownShort2 = reader.ReadUInt16();
            }
            UnknownFloat3 = reader.ReadSingle();
            UnknownFloat4 = reader.ReadSingle();
            UnknownFloat5 = reader.ReadSingle();
            UnknownFloat6 = reader.ReadSingle();
            UnknownFloat7 = reader.ReadSingle();
            UnknownFloat8 = reader.ReadSingle();
            UnknownFloat9 = reader.ReadSingle();
            UnknownFloat10 = reader.ReadSingle();
            UnknownFloat11 = reader.ReadSingle();
            UnknownFloat12 = reader.ReadSingle();
            UnknownFloat13 = reader.ReadSingle();
            UnknownFloat14 = reader.ReadSingle();
            UnknownFloat15 = reader.ReadSingle();
            UnknownFloat16 = reader.ReadSingle();
        }
    }
}