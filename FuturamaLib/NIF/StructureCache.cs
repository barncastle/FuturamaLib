using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FuturamaLib.NIF
{
    internal static class StructureCache
    {
        private readonly static Dictionary<string, Type> Collection;

        static StructureCache()
        {
            var _namespace = typeof(StructureCache).Namespace;

            Collection = Assembly.GetExecutingAssembly().GetTypes()
                .Where(x => x.Namespace.StartsWith(_namespace))
                .ToDictionary(x => x.Name);
        }

        public static bool TryGetValue(string name, out Type type) => Collection.TryGetValue(name, out type);
    }
}