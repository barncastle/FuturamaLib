using System;

namespace FuturamaLib.Extensions
{
    internal static class Arrays
    {
        public static T[] InitWithInstance<T>(int length) where T : new()
        {
            var array = new T[length];
            for (int i = 0; i < length; i++)
                array[i] = new T();

            return array;
        }

        public static T[] InitWithInstance<T>(int length, params object[] args)
        {
            var array = new T[length];
            for (int i = 0; i < length; i++)
                array[i] = (T)Activator.CreateInstance(typeof(T), args);

            return array;
        }

        public static T[] InitWithValue<T>(int length, T value)
        {
            var array = new T[length];

            if (!value.Equals(default(T)))
                for (int i = 0; i < length; i++)
                    array[i] = value;

            return array;
        }
    }
}