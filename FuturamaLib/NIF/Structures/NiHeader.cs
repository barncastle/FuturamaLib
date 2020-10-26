using FuturamaLib.NIF.Enums;
using System;
using System.IO;
using System.Text;

namespace FuturamaLib.NIF.Structures
{
    public class NiHeader
    {
        public string VersionString;

        public NifVersion Version;

        public uint NumBlocks;

        public NiHeader(BinaryReader reader)
        {
            VersionString = ReadVersionString(reader);
            Version = (NifVersion)reader.ReadUInt32();
            NumBlocks = reader.ReadUInt32();

            if (!Enum.IsDefined(Version))
                throw new NotSupportedException($"Unsupported version: {VersionString} {Version}");
        }

        private string ReadVersionString(BinaryReader reader)
        {
            var sb = new StringBuilder(0x40);

            char b;
            while ((b = (char)reader.ReadByte()) != 0xA)
                sb.Append(b);

            return sb.ToString();
        }
    }
}