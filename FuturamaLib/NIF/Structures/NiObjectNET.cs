using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiObjectNET : NiObject
    {
        public NiString Name;

        public NiRef<NiExtraData>[] ExtraData;

        public NiRef<NiTimeController> Controller;

        public NiObjectNET(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            Name = new NiString(reader);
            ExtraData = new NiRef<NiExtraData>[]
            {
                new NiRef<NiExtraData>(reader.ReadUInt32())
            };
            Controller = new NiRef<NiTimeController>(reader.ReadUInt32());
        }
    }
}