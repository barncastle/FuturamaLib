using System.Runtime.InteropServices;

namespace FuturamaLib.LDB
{
    public struct Locale
    {
        public readonly uint StartOffset;
        public readonly uint Size;
        // Note: it's assumed the remaining bytes are junk padding
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 24)]
        public readonly string Name;

        public readonly uint EndOffset => StartOffset + Size;
    }
}