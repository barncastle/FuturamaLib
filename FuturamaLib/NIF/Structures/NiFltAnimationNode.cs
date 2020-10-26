using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiFltAnimationNode : NiSwitchNode
    {
        public float Period;

        // m_bBounce overrides something

        public NiFltAnimationNode(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            Period = reader.ReadSingle();
        }
    }
}