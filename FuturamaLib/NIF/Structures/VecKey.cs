using FuturamaLib.NIF.Enums;
using System;
using System.IO;
using System.Numerics;

namespace FuturamaLib.NIF.Structures
{
    public class VecKey : BaseKey
    {
        public float Time;

        public Vector3 Value;

        public Vector3 Forward;

        public Vector3 Backward;

        public Vector3 TBC;

        public VecKey(BinaryReader reader, KeyType type) : base(reader, type)
        {
            Time = reader.ReadSingle();
            if (type < KeyType.LINEAR_KEY || type > KeyType.TBC_KEY)
            {
                throw new Exception("Invalid eKeyType!");
            }
            if (type == KeyType.LINEAR_KEY)
            {
                Value = reader.Read<Vector3>();
            }
            if (type == KeyType.QUADRATIC_KEY)
            {
                Value = reader.Read<Vector3>();
                Forward = reader.Read<Vector3>();
                Backward = reader.Read<Vector3>();
            }
            if (type == KeyType.TBC_KEY)
            {
                Value = reader.Read<Vector3>();
                TBC = reader.Read<Vector3>();
            }
        }
    }
}