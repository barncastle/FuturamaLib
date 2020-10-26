using FuturamaLib.NIF.Enums;
using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiObject
    {
        public NIFReader File;

        public NifVersion Version => File.Header.Version;

        public NiObject(NIFReader file, BinaryReader _)
        {
            File = file;
        }
    }
}