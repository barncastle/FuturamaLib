using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiSkinInstance : NiObject
    {
        public NiRef<NiSkinData> Data;

        public NiRef<NiNode> SkeletonRoot;

        public NiRef<NiNode>[] Bones;

        public NiSkinInstance(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            Data = new NiRef<NiSkinData>(reader);
            SkeletonRoot = new NiRef<NiNode>(reader);
            Bones = new NiRef<NiNode>[reader.ReadUInt32()];
            for (var i = 0; i < Bones.Length; i++)
                Bones[i] = new NiRef<NiNode>(reader);
        }
    }
}