using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiSwitchNode : NiNode
    {
        public int Index;

        public NiSwitchNode(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            Index = reader.ReadInt32();
        }
    }
}