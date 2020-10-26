using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class LODRange
    {
        public float NearExtent;

        public float FarExtent;

        public LODRange(BinaryReader reader)
        {
            NearExtent = reader.ReadSingle();
            FarExtent = reader.ReadSingle();
        }
    }
}