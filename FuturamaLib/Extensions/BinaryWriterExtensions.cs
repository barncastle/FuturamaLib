using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace FuturamaLib.Extensions
{
    public static class BinaryWriterExtensions
    {
        public static void Write<T>(this BinaryWriter writer, T value) where T : struct
        {
            var size = Marshal.SizeOf<T>();

            var buffer = new byte[size];
            var handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            Marshal.StructureToPtr(value, handle.AddrOfPinnedObject(), true);
            handle.Free();

            writer.Write(buffer);
        }

        public static void WriteArray<T>(this BinaryWriter writer, T[] values) where T : struct
        {
            var size = Marshal.SizeOf<T>();
            var buffer = new byte[size * values.Length];
            var handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);

            for (var i = 0; i < values.Length; i++)
                Marshal.StructureToPtr(values[i], handle.AddrOfPinnedObject() + (i * size), false);

            handle.Free();
            writer.Write(buffer);
        }

        public static void WriteCString(this BinaryWriter writer, string value)
        {
            var buffer = Encoding.UTF8.GetBytes(value);
            writer.Write(buffer);
            writer.Write((byte)0);
        }

        public static void WriteWCString(this BinaryWriter writer, string value)
        {
            var buffer = Encoding.Unicode.GetBytes(value);
            writer.Write(buffer);
            writer.Write((ushort)0);
        }

        public static void WriteUInt32BE(this BinaryWriter writer, uint value)
        {
            writer.Write((byte)((value >> 24) & 0xFF));
            writer.Write((byte)((value >> 16) & 0xFF));
            writer.Write((byte)((value >> 8) & 0xFF));
            writer.Write((byte)(value & 0xFF));
        }

        public static void Align(this BinaryWriter writer, int alignment)
        {
            var diff = writer.BaseStream.Position % alignment;
            if (diff != 0)
                writer.BaseStream.Position += alignment - diff;
        }
    }
}