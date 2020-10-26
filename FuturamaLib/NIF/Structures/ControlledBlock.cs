using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class ControlledBlock
    {
        public NiString TargetName;
        public NiRef<NiTimeController> Controller;

        public ControlledBlock(BinaryReader reader)
        {
            TargetName = new NiString(reader);
            Controller = new NiRef<NiTimeController>(reader);
        }
    }
}