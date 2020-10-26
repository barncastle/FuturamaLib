using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiFooter
    {
        public NiRef<NiObject>[] RootNodes;

        public NiFooter(BinaryReader reader)
        {
            RootNodes = new NiRef<NiObject>[reader.ReadUInt32()];
            for (var i = 0; i < RootNodes.Length; i++)
                RootNodes[i] = new NiRef<NiObject>(reader.ReadUInt32());
        }
    }
}