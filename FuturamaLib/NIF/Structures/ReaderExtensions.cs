using FuturamaLib.NIF.Enums;
using System.IO;
using System.Runtime.CompilerServices;
using Matrix = System.Numerics.Matrix4x4;

namespace FuturamaLib.NIF.Structures
{
    public static class ReaderExtensions
    {
        public static bool ReadBoolean(this BinaryReader reader, NifVersion version)
        {
            if (version < NifVersion.VER_4_1_0_1)
                return reader.ReadUInt32() != 0;

            return reader.ReadBoolean();
        }

        public static T Read<T>(this BinaryReader reader) where T : unmanaged
        {
            var result = reader.ReadBytes(Unsafe.SizeOf<T>());
            return Unsafe.ReadUnaligned<T>(ref result[0]);
        }

        public unsafe static T[] ReadArray<T>(this BinaryReader reader, long size) where T : unmanaged
        {
            var buffer = reader.ReadBytes(Unsafe.SizeOf<T>() * (int)size);
            var result = new T[size];

            if (buffer.Length > 0)
                Unsafe.CopyBlockUnaligned(Unsafe.AsPointer(ref result[0]), Unsafe.AsPointer(ref buffer[0]), (uint)buffer.Length);

            return result;
        }

        public static Color4 ReadColor3(this BinaryReader reader)
        {
            return new Color4(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(), 0);
        }

        public static Color4 ReadColor4Byte(this BinaryReader reader)
        {
            return new Color4(reader.ReadByte(), reader.ReadByte(), reader.ReadByte(), reader.ReadByte());
        }

        public static Matrix ReadMatrix33(this BinaryReader reader)
        {
            return new Matrix(
                reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(), 0,
                reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(), 0,
                reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(), 0,
                0, 0, 0, 1
           );
        }
    }
}