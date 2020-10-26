using FuturamaLib.NIF.Enums;
using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiVisData : NiObject
    {
        public ByteKey[] Keys;

        public NiVisData(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            Keys = new ByteKey[reader.ReadUInt32()];
            for (var i = 0; i < Keys.Length; i++)
                Keys[i] = new ByteKey(reader, KeyType.LINEAR_KEY);
        }
    }
}