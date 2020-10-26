using FuturamaLib.NIF.Enums;
using System;
using System.IO;
using System.Numerics;

namespace FuturamaLib.NIF.Structures
{
    public class QuatKey
    {
        public float Time;

        public Vector4 Value;

        public Vector3 TBC;

        public QuatKey(BinaryReader reader, KeyType type)
        {
            Time = reader.ReadSingle();

            if (type < KeyType.LINEAR_KEY || type > KeyType.TBC_KEY)
                throw new Exception("Invalid eKeyType");

            Value = reader.Read<Vector4>();

            if (type == KeyType.TBC_KEY)
                TBC = reader.Read<Vector3>();
        }
    }
}