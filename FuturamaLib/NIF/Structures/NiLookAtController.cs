using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiLookAtController : NiTimeController
    {
        public NiRef<NiNode> CameraTargetNode;

        public NiLookAtController(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            CameraTargetNode = new NiRef<NiNode>(reader);
        }
    }
}