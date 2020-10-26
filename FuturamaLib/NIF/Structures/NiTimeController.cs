using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiTimeController : NiObject
    {
        public NiRef<NiTimeController> NextController;

        public ushort Flags;

        public float Frequency;

        public float Phase;

        public float StartTime;

        public float StopTime;

        public NiRef<NiObjectNET> Target;

        public NiTimeController(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            NextController = new NiRef<NiTimeController>(reader);
            Flags = reader.ReadUInt16();
            Frequency = reader.ReadSingle();
            Phase = reader.ReadSingle();
            StartTime = reader.ReadSingle();
            StopTime = reader.ReadSingle();
            Target = new NiRef<NiObjectNET>(reader);
        }
    }
}