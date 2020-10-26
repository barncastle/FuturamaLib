using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiUDSFileObject : NiAVObject
    {
        public uint BufferSize;
        public byte[] Data;

        public NiUDSFileObject(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            BufferSize = reader.ReadUInt32();
            Data = reader.ReadBytes((int)BufferSize);
        }
    }
}