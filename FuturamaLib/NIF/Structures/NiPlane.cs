using System.IO;
using System.Numerics;

namespace FuturamaLib.NIF.Structures
{
    public class NiPlane
    {
        public Vector3 Normal;
        public float Constant;

        public NiPlane(BinaryReader reader)
        {
            Normal = reader.Read<Vector3>();
            Constant = reader.ReadSingle();
        }
    }
}