using System.IO;
using System.Numerics;

namespace FuturamaLib.NIF.Structures
{
    public class NiScreenLODData : NiLODData
    {
        public Vector3 BoundCenter;

        public float BoundRadius;

        public Vector3 WorldCenter;

        public float WorldRadius;

        public float[] ProportionLevels;

        public NiScreenLODData(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            BoundCenter = reader.Read<Vector3>();
            BoundRadius = reader.ReadSingle();
            WorldCenter = reader.Read<Vector3>();
            WorldRadius = reader.ReadSingle();
            ProportionLevels = reader.ReadArray<float>(reader.ReadInt32());
        }
    }
}