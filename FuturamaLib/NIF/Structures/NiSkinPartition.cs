using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiSkinPartition : NiObject
    {
        public SkinPartition[] Partitions;

        public NiSkinPartition(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            Partitions = new SkinPartition[reader.ReadUInt32()];
            for (var i = 0; i < Partitions.Length; i++)
                Partitions[i] = new SkinPartition(reader);
        }
    }
}