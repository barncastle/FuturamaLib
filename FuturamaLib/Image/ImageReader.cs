using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FuturamaLib.Image
{
    public class ImageReader : IDisposable, IReadOnlyDictionary<string, ImageEntry>
    {
        public RootDirectory RootDirectory { get; private set; }
        public IEnumerable<string> Keys => Entries.Keys;
        public IEnumerable<ImageEntry> Values => Entries.Values;
        public int Count => Entries.Count;

        private readonly Dictionary<string, ImageEntry> Entries;
        private readonly BinaryReader Reader;

        public ImageReader(string filepath) : this(File.OpenRead(filepath))
        {
        }

        public ImageReader(Stream stream)
        {
            Entries = new Dictionary<string, ImageEntry>(0x2000, StringComparer.OrdinalIgnoreCase);
            Reader = new BinaryReader(stream, Encoding.ASCII, true);
            RootDirectory = new RootDirectory(Reader);

            var directories = new List<ImageEntry>(0x4);

            while (Reader.BaseStream.Position < RootDirectory.EndOffset)
            {
                var parent = directories.Count > 0 ? directories[^1] : null;
                var entry = new ImageEntry(Reader, parent?.FullName);

                // update the directory hierachy
                if (parent?.EndOffset <= Reader.BaseStream.Position)
                    directories.RemoveAll(d => Reader.BaseStream.Position >= d.EndOffset);

                if (entry.IsDirectory)
                    directories.Add(entry);
                else
                    Entries.Add(entry.FullName, entry);
            }
        }

        #region Extraction

        public void ExtractAll(string outputdirectory)
        {
            foreach (var item in Entries)
            {
                item.Value.Extract(Reader, outputdirectory);
            }
        }

        public void ExtractFile(string filename, string outputdirectory)
        {
            if (TryGetValue(filename, out var entry))
                entry.Extract(Reader, outputdirectory);
        }

        public void ExtractFile(ImageEntry entry, string outputdirectory)
        {
            entry.Extract(Reader, outputdirectory);
        }

        #endregion Extraction

        #region Reading

        public Stream OpenFile(string filename)
        {
            return TryGetValue(filename, out var entry) ? entry.GetStream(Reader) : null;
        }

        public Stream OpenFile(ImageEntry entry)
        {
            return entry.GetStream(Reader);
        }

        #endregion Reading

        #region Interface

        public ImageEntry this[string key] => Entries[key];

        public bool ContainsKey(string key) => Entries.ContainsKey(key);

        public bool TryGetValue(string key, out ImageEntry value) => Entries.TryGetValue(key, out value);

        public IEnumerator<KeyValuePair<string, ImageEntry>> GetEnumerator() => Entries.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => Entries.GetEnumerator();

        public void Dispose()
        {
            Reader.Dispose();
            GC.SuppressFinalize(this);
        }

        #endregion Interface
    }
}