using Common.Extensions;
using FuturamaLib.Extensions;
using System.IO;

namespace FuturamaLib.LDB
{
    public class StringEntry
    {
        public readonly string Key;
        public readonly string Database;
        public readonly string PathA;
        public readonly string PathB;
        public readonly string[] Values;

        public StringEntry(BinaryReader reader)
        {
            Key = reader.ReadCString();
            Database = reader.ReadCString();
            PathA = reader.ReadCString();
            PathB = reader.ReadCString();
            Values = Arrays.InitWithValue(LDBReader.NumLocales, "");
        }

        public override string ToString() => Key;
    }
}