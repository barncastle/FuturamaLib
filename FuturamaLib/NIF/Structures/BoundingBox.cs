using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace FuturamaLib.NIF.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    public struct BoundingBox : IEquatable<BoundingBox>
    {
        public Vector3 Max;
        public Vector3 Min;

        public BoundingBox(Vector3 min, Vector3 max)
        {
            Min = min;
            Max = max;
        }

        public bool Equals(BoundingBox other)
        {
            return other.Min == Min && other.Max == Max;
        }

        public override string ToString()
        {
            return $"{Min}, {Max}";
        }
    }
}