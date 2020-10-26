using System.IO;
using System.Numerics;

namespace FuturamaLib.NIF.Structures
{
    public class Morph
    {
        public KeyGroup<FloatKey> Keys;

        public Vector3[] Vectors;

        public Morph(BinaryReader reader, uint numVertices)
        {
            Keys = new KeyGroup<FloatKey>(reader);
            Vectors = reader.ReadArray<Vector3>(numVertices);
        }
    }
}