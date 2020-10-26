using FuturamaLib.NIF.Enums;
using System;
using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class Color4Key : BaseKey
    {
        public float Time;

        public Color4 Value;

        public Color4 Forward;

        public Color4 Backward;

        public Color4Key(BinaryReader reader, KeyType type) : base(reader, type)
        {
            Time = reader.ReadSingle();
            if (type < KeyType.LINEAR_KEY || type > KeyType.TBC_KEY)
            {
                throw new Exception("Invalid eKeyType!");
            }
            Value = reader.Read<Color4>();
            if (type == KeyType.QUADRATIC_KEY)
            {
                Forward = reader.Read<Color4>();
                Backward = reader.Read<Color4>();
            }
        }
    }
}