using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiBooleanExtraData : NiExtraData
    {
        public bool Data;

        public NiBooleanExtraData(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            Data = reader.ReadBoolean();
        }
    }
}