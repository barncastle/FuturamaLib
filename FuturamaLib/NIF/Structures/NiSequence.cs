using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiSequence : NiObject
    {
        public NiString Name;
        public NiString AccumRootName;
        public NiRef<NiTextKeyExtraData> TextKeys;
        public uint NumControlledBlocks;
        public ControlledBlock[] ControlledBlock;

        public NiSequence(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            Name = new NiString(reader);
            AccumRootName = new NiString(reader);
            TextKeys = new NiRef<NiTextKeyExtraData>(reader);
            NumControlledBlocks = reader.ReadUInt32();

            ControlledBlock = new ControlledBlock[NumControlledBlocks];
            for (var i = 0; i < NumControlledBlocks; i++)
                ControlledBlock[i] = new ControlledBlock(reader);
        }
    }
}