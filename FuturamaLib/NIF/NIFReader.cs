using FuturamaLib.NIF.Structures;
using System;
using System.Collections.Generic;
using System.IO;

namespace FuturamaLib.NIF
{
    public class NIFReader
    {
        public NiHeader Header;
        public NiFooter Footer;
        public Dictionary<uint, NiObject> ObjectsByRef;

        public NIFReader(string filepath) : this(File.OpenRead(filepath))
        {
        }

        public NIFReader(Stream stream)
        {
            using var reader = new BinaryReader(stream);

            Header = new NiHeader(reader);
            ReadNiObjects(reader);
            Footer = new NiFooter(reader);
            FixReferences();
        }

        private void ReadNiObjects(BinaryReader reader)
        {
            ObjectsByRef = new Dictionary<uint, NiObject>((int)Header.NumBlocks);

            for (var i = 0u; i < Header.NumBlocks; i++)
            {
                var typeName = new string(reader.ReadChars(reader.ReadInt32()));

                if (!StructureCache.TryGetValue(typeName, out var type))
                    throw new NotImplementedException(typeName);

                ObjectsByRef.Add(i, (NiObject)Activator.CreateInstance(type, this, reader));
            }
        }

        private void FixReferences()
        {
            foreach (var obj in ObjectsByRef)
                FixReferences(obj.Value);

            for (var i = 0; i < Footer.RootNodes.Length; i++)
                Footer.RootNodes[i].SetRef(this);
        }

        private void FixReferences(NiObject obj)
        {
            var fields = obj.GetType().GetFields();

            for (var i = 0; i < fields.Length; i++)
            {
                var fieldInfo = fields[i];

                var fieldType = fieldInfo.FieldType.IsArray ?
                    fieldInfo.FieldType.GetElementType() :
                    fieldInfo.FieldType;

                if (typeof(INiRef).IsAssignableFrom(fieldType))
                {
                    if (fieldInfo.FieldType.IsArray)
                    {
                        var array = (INiRef[])fieldInfo.GetValue(obj);
                        Array.ForEach(array, e => e.SetRef(this));
                    }
                    else
                    {
                        ((INiRef)fieldInfo.GetValue(obj)).SetRef(this);
                    }
                }
            }
        }
    }
}