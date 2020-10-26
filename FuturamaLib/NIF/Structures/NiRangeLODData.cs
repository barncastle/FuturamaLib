using System.IO;
using System.Numerics;

namespace FuturamaLib.NIF.Structures
{
    public class NiRangeLODData : NiLODData
    {
        public Vector3 LODCenter;

        public LODRange[] LODLevels;

        public NiRangeLODData(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            LODCenter = reader.Read<Vector3>();

            LODLevels = new LODRange[reader.ReadUInt32()];
            for (var i = 0; i < LODLevels.Length; i++)
                LODLevels[i] = new LODRange(reader);
        }
    }
}