using FuturamaLib.NIF.Enums;
using System;
using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class StringKey
    {
        public float Time;

        public NiString Value;

        public StringKey(BinaryReader reader, KeyType type)
        {
            Time = reader.ReadSingle();
            if (type != KeyType.LINEAR_KEY)
            {
                throw new Exception("Invalid eKeyType");
            }
            Value = new NiString(reader);
        }
    }
}