using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiCollisionObject : NiObject
    {
        public NiRef<NiAVObject> Target;

        public NiCollisionObject(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            Target = new NiRef<NiAVObject>(reader);
        }
    }
}