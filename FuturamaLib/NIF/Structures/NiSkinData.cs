using FuturamaLib.NIF.Enums;
using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiSkinData : NiObject
    {
        public SkinTransform Transform;

        public NiRef<NiSkinPartition> Partition;

        public bool HasVertexWeights;

        public SkinData[] BoneList;

        public NiSkinData(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            HasVertexWeights = true;
            Transform = new SkinTransform(reader);
            var skinCount = reader.ReadUInt32();
            Partition = new NiRef<NiSkinPartition>(reader);

            if (Version >= NifVersion.VER_4_2_1_0)
            {
                HasVertexWeights = reader.ReadBoolean();
            }

            if (HasVertexWeights)
            {
                BoneList = new SkinData[skinCount];
                for (var i = 0; i < BoneList.Length; i++)
                    BoneList[i] = new SkinData(reader, HasVertexWeights);
            }
        }
    }
}