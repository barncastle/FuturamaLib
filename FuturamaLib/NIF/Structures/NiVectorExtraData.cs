using System.IO;
using System.Numerics;

namespace FuturamaLib.NIF.Structures
{
    public class NiVectorExtraData : NiExtraData
    {
        public Vector3 Data;

        public float UnknownFloat;

        public NiVectorExtraData(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            Data = reader.Read<Vector3>();
            UnknownFloat = reader.ReadSingle();
        }
    }
}