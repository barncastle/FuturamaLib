using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiDynamicEffect : NiAVObject
    {
        public bool SwitchState;

        public NiDynamicEffect(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            SwitchState = true;
        }
    }
}