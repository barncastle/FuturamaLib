using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiRef<T> : INiRef where T : NiObject
    {
        public T Object { get; private set; }
        public uint RefId { get; }
        public bool IsValid => RefId != uint.MaxValue;

        public NiRef(uint refId)
        {
            RefId = refId;
        }

        public NiRef(BinaryReader reader) : this(reader.ReadUInt32())
        {
        }

        public void SetRef(NIFReader file)
        {
            if (IsValid)
                Object = (T)file.ObjectsByRef[RefId];
        }
    }
}