using Common.Extensions;
using CsvHelper;
using FuturamaLib.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;

namespace FuturamaLib.LDB
{
    public class LDBReader : IReadOnlyDictionary<string, StringEntry>
    {
        public const uint Magic = 0x4C444230;
        public const int NumLocales = 15;

        public Header Header { get; }
        public Locale[] Locales { get; }
        public IEnumerable<string> Keys => Entries.Keys;
        public IEnumerable<StringEntry> Values => Entries.Values;
        public int Count => Entries.Count;

        private readonly Dictionary<string, StringEntry> Entries;

        public LDBReader(string filepath) : this(File.OpenRead(filepath))
        {
        }

        public LDBReader(Stream stream)
        {
            using var reader = new BinaryReader(stream);

            Header = reader.Read<Header>();
            if (Header.Magic != Magic)
                throw new FormatException($"Invalid header. Expected {Magic:X8}, got {Header.Magic:X8}");

            Locales = reader.ReadArray<Locale>(NumLocales);

            Debug.Assert(stream.Position == Header.EntryTableOffset);

            var entries = Arrays.InitWithInstance<StringEntry>(Header.NumEntries, reader);

            Debug.Assert(stream.Position == Header.EntryTableOffset + Header.EntryTableSize);

            // populate the string values
            for (var i = 0; i < NumLocales; i++)
            {
                Debug.Assert(stream.Position == Locales[i].StartOffset);

                var count = Locales[i].Size / 2; // some locales are partial or empty

                for (var j = 0; j < entries.Length && j < count; j++)
                {
                    entries[j].Values[i] = reader.ReadWCString();
                }
            }

            Debug.Assert(stream.Position == stream.Length);

            Entries = entries.ToDictionary(x => x.Key, StringComparer.OrdinalIgnoreCase);
        }

        #region Helpers

        public int GetLocaleIndex(string locale)
        {
            return Array.FindIndex(Locales, x => x.Name.Equals(locale, StringComparison.OrdinalIgnoreCase));
        }

        public string GetValue(string key, string locale)
        {
            if (Entries.TryGetValue(key, out var entry))
            {
                var index = GetLocaleIndex(locale);
                if (index > -1)
                    return entry.Values[index];
            }

            return null;
        }

        public string GetValue(string key, int localeIndex)
        {
            if (Entries.TryGetValue(key, out var entry))
                if (localeIndex >= 0 && localeIndex < NumLocales)
                    return entry.Values[localeIndex];

            return null;
        }

        /// <summary>
        /// Exports the Language DB to a CSV file
        /// </summary>
        /// <param name="filepath"></param>
        public void Export(string filepath)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(filepath));

            using var sr = new StreamWriter(filepath);
            using var csv = new CsvWriter(sr, CultureInfo.InvariantCulture);

            csv.Configuration.RegisterClassMap(new StringEntryClassMap(this));
            csv.WriteRecords(Values);
            sr.Flush();
        }

        #endregion Helpers

        #region Interface

        public StringEntry this[string key] => Entries[key];

        public bool ContainsKey(string key) => Entries.ContainsKey(key);

        public bool TryGetValue(string key, out StringEntry value) => Entries.TryGetValue(key, out value);

        public IEnumerator<KeyValuePair<string, StringEntry>> GetEnumerator() => Entries.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => Entries.GetEnumerator();

        #endregion Interface
    }
}