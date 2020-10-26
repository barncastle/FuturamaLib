using CsvHelper.Configuration;

namespace FuturamaLib.LDB
{
    internal sealed class StringEntryClassMap : ClassMap<StringEntry>
    {
        public StringEntryClassMap(LDBReader reader)
        {
            Map(m => m.Key);
            Map(m => m.Database);
            Map(m => m.PathA);
            Map(m => m.PathB);
            Map(m => m.Values).Name(reader.Locales[0].Name);

            // csvhelper only prints one name for arrays
            // so add the rest as unmapped fields
            for (var i = 1; i < reader.Locales.Length; i++)
                Map().Name(reader.Locales[i].Name);
        }
    }
}