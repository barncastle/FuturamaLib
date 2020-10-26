using FuturamaLib.NIF.Enums;
using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiTextKeyExtraData : NiExtraData
    {
        public uint UnknownInt1;

        public StringKey[] TextKeys;

        public NiTextKeyExtraData(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            UnknownInt1 = reader.ReadUInt32();

            TextKeys = new StringKey[reader.ReadUInt32()];
            for (var i = 0; i < TextKeys.Length; i++)
                TextKeys[i] = new StringKey(reader, KeyType.LINEAR_KEY);
        }
    }
}