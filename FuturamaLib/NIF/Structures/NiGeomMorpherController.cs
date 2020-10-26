using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiGeomMorpherController : NiInterpController
    {
        public NiRef<NiMorphData> Data;

        public bool AlwaysUpdate;

        public NiGeomMorpherController(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            Data = new NiRef<NiMorphData>(reader);
            AlwaysUpdate = reader.ReadBoolean();
        }
    }
}