using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Common.Extensions
{
    public static class BinaryReaderExtensions
    {
        public static T Read<T>(this BinaryReader reader) where T : struct
        {
            var buffer = reader.ReadBytes(Marshal.SizeOf<T>());
            var handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            var result = Marshal.PtrToStructure<T>(handle.AddrOfPinnedObject());
            handle.Free();
            return result;
        }

        public static T[] ReadArray<T>(this BinaryReader reader, int count) where T : struct
        {
            var size = Marshal.SizeOf<T>();
            var buffer = reader.ReadBytes(size * count);
            var handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            var result = new T[count];

            for (var i = 0; i < count; i++)
                result[i] = Marshal.PtrToStructure<T>(handle.AddrOfPinnedObject() + (i * size));

            handle.Free();
            return result;
        }

        public static string ReadCString(this BinaryReader reader)
        {
            var sb = new StringBuilder(0x40);

            byte b;
            while ((b = reader.ReadByte()) != 0)
                sb.Append((char)b);

            return sb.ToString();
        }

        public static string ReadWCString(this BinaryReader reader)
        {
            var sb = new StringBuilder(0x40);

            ushort b;
            while ((b = reader.ReadUInt16()) != 0)
                sb.Append((char)b);

            return sb.ToString();
        }

        public static uint ReadUInt32BE(this BinaryReader reader)
        {
            var buf = reader.ReadBytes(4);
            return (uint)((buf[0] << 24) | (buf[1] << 16) | (buf[2] << 8) | buf[3]); ;
        }

        public static void Align(this BinaryReader reader, int alignment)
        {
            var diff = reader.BaseStream.Position % alignment;
            if (diff != 0)
                reader.BaseStream.Position += alignment - diff;
        }
    }
}