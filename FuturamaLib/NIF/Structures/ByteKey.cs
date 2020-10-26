using FuturamaLib.NIF.Enums;
using System;
using System.IO;
using System.Numerics;

namespace FuturamaLib.NIF.Structures
{
    public class ByteKey
    {
        public float Time;

        public byte Value;

        public Vector3 TBC;

        public ByteKey(BinaryReader reader, KeyType type)
        {
            Time = reader.ReadSingle();
            if (type != KeyType.LINEAR_KEY)
            {
                throw new Exception("Invalid eKeyType");
            }
            Value = reader.ReadByte();
            if (type == KeyType.TBC_KEY)
            {
                TBC = reader.Read<Vector3>();
            }
        }
    }
}