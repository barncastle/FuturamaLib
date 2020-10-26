using System.IO;

namespace FuturamaLib.Image
{
    public class RootDirectory
    {
        public readonly Platform Platform;
        public readonly long Size;
        public readonly long EndOffset;

        public RootDirectory(BinaryReader reader)
        {
            var value = reader.ReadUInt32();

            Platform = (Platform)(value & 3);
            Size = value & ~3;
            EndOffset = reader.BaseStream.Position + Size - 4; // sizeof(value)
        }

        public override string ToString()
        {
            return $"Platform: {Platform}, Size: {Size}, End: {EndOffset}";
        }
    }
}