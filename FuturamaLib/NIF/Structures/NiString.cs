using System;
using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiString
    {
        public string Value;

        public NiString(BinaryReader reader)
        {
            var count = reader.ReadUInt32();
            if (count > 16384)
                throw new NotSupportedException("String too long. Not a NIF file or unsupported format?");
            Value = new string(reader.ReadChars((int)count));
        }

        public override string ToString()
        {
            return Value;
        }
    }
}