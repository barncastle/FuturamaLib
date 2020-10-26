using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class SkinWeight
    {
        public ushort Index;

        public float Weight;

        public SkinWeight(BinaryReader reader)
        {
            Index = reader.ReadUInt16();
            Weight = reader.ReadSingle();
        }
    }
}