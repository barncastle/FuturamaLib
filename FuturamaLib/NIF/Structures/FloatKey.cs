using FuturamaLib.NIF.Enums;
using System;
using System.IO;
using System.Numerics;

namespace FuturamaLib.NIF.Structures
{
    public class FloatKey : BaseKey
    {
        public float Time;

        public float Value;

        public float Forward;

        public float Backward;

        public Vector3 TBC;

        public FloatKey(BinaryReader reader, KeyType type) : base(reader, type)
        {
            Time = reader.ReadSingle();
            Value = reader.ReadSingle();
            if (type < KeyType.LINEAR_KEY || type > KeyType.TBC_KEY)
            {
                throw new Exception("Invalid eKeyType!");
            }
            if (type == KeyType.QUADRATIC_KEY)
            {
                Forward = reader.ReadSingle();
                Backward = reader.ReadSingle();
            }
            if (type == KeyType.TBC_KEY)
            {
                TBC = reader.Read<Vector3>();
            }
        }
    }
}