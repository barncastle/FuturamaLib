using FuturamaLib.NIF.Enums;
using System;
using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class KeyGroup<T> where T : BaseKey
    {
        public KeyType Interpolation;

        public T[] Values;

        public KeyGroup(BinaryReader reader)
        {
            Values = new T[reader.ReadUInt32()];

            if (Values.Length != 0)
                Interpolation = (KeyType)reader.ReadUInt32();

            for (var i = 0; i < Values.Length; i++)
                Values[i] = (T)Activator.CreateInstance(typeof(T), reader, Interpolation);
        }
    }
}