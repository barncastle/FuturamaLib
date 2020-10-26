using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiMorphData : NiObject
    {
        public uint NumMorphs;

        public uint NumVertices;

        public byte RelativeTargets;

        public Morph[] Morphs;

        public NiMorphData(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            NumMorphs = reader.ReadUInt32();
            NumVertices = reader.ReadUInt32();
            RelativeTargets = reader.ReadByte();

            Morphs = new Morph[NumMorphs];
            for (var i = 0; i < NumMorphs; i++)
                Morphs[i] = new Morph(reader, NumVertices);
        }
    }
}