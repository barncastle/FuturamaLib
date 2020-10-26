using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiGeometry : NiAVObject
    {
        public NiRef<NiGeometryData> Data;

        public NiRef<NiSkinInstance> SkinInstance;

        public NiGeometry(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            Data = new NiRef<NiGeometryData>(reader);
            SkinInstance = new NiRef<NiSkinInstance>(reader);
        }
    }
}