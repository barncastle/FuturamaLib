using Common.Extensions;
using System.IO;

namespace FuturamaLib.Image
{
    public class ImageEntry
    {
        public readonly string Name;
        public readonly string FullName;
        public readonly int Size;
        public readonly long StartOffset;
        public readonly long EndOffset;
        public readonly bool IsDirectory;

        public ImageEntry(BinaryReader reader, string directory = "")
        {
            Name = reader.ReadCString();
            reader.Align(4);
            Size = reader.ReadInt32();
            IsDirectory = (Name[0] & 0x80) > 0;

            if (IsDirectory)
            {
                Name = (char)(Name[0] ^ 0x80) + Name[1..]; // remove directory indicator bit
                StartOffset = reader.BaseStream.Position;
                EndOffset = reader.BaseStream.Position + Size - 4; // sizeof(Size)
            }
            else
            {
                StartOffset = reader.ReadInt32();
                EndOffset = StartOffset + Size;
            }

            FullName = Path.Combine(directory ?? "", Name);
        }

        internal void Extract(BinaryReader reader, string outputPath)
        {
            if (!IsDirectory && EndOffset < reader.BaseStream.Length)
            {
                var filepath = Path.Combine(outputPath, FullName);
                var folderpath = Path.GetDirectoryName(filepath);

                // create directory structure
                Directory.CreateDirectory(folderpath);

                // create file
                using var fs = File.Create(filepath);
                reader.BaseStream.Position = StartOffset;
                fs.Write(reader.ReadBytes(Size));
                fs.Flush();
            }
        }

        internal Stream GetStream(BinaryReader reader)
        {
            MemoryStream stream = null;

            if (!IsDirectory && EndOffset < reader.BaseStream.Length)
            {
                reader.BaseStream.Position = StartOffset;
                stream = new MemoryStream(reader.ReadBytes(Size));
            }

            return stream;
        }

        public override string ToString() => FullName;
    }
}