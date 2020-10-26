using Common.Extensions;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace FuturamaLib.FNT
{
    public class FNTReader : IReadOnlyCollection<Glyph>
    {
        public const int NumGlyphs = 256;

        public Header Header { get; }

        public int Count => Entries.Length;

        private readonly Glyph[] Entries;

        public FNTReader(string filepath) : this(File.OpenRead(filepath))
        {
        }

        public FNTReader(Stream stream)
        {
            using var reader = new BinaryReader(stream);

            Header = reader.Read<Header>();
            Entries = reader.ReadArray<Glyph>(NumGlyphs);

            Debug.Assert(stream.Position == stream.Length);
        }

        public IEnumerator<Glyph> GetEnumerator() => Entries.AsEnumerable().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}