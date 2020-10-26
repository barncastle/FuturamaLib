using FuturamaLib.FNT;
using FuturamaLib.LDB;
using FuturamaLib.NIF;
using FuturamaLib.VAG;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace FuturamaLib.Text
{
    [TestClass]
    public class Main
    {
        private const string BaseDirectory = @"D:\Test";
        private const string PS2Directory = @"D:\Test\ps2";
        private const string XboxDirectory = @"D:\Test\xbox";
        private static string TempDirectory;

        [ClassInitialize()]
        public static void Startup(TestContext _)
        {
            Cleanup();
            TempDirectory = Directory.CreateDirectory("test").FullName;
        }

        [ClassCleanup()]
        public static void Cleanup()
        {
            if (Directory.Exists("test"))
                Directory.Delete("test", true);
        }

        [TestMethod]
        public void LDBReaderTest()
        {
            var dbs = Directory.GetFiles(BaseDirectory, "*.ldb", SearchOption.AllDirectories);

            foreach (var filepath in dbs)
            {
                _ = new LDBReader(filepath);
            }
        }

        [TestMethod]
        public void LDBExportTest()
        {
            var filepath = Path.Combine(XboxDirectory, "language\\l1a1-gvr.ldb");
            var outputpath = Path.Combine(TempDirectory, "l1a1-gvr.csv");

            var reader = new LDBReader(filepath);
            reader.Export(outputpath);

            Assert.IsTrue(File.Exists(outputpath));

            // check line_count - header == entries
            var linecount = File.ReadAllLines(outputpath).Length - 1;

            Assert.IsTrue(linecount == reader.Count);
        }

        [TestMethod]
        public void VAGReaderTest()
        {
            var sounds = Directory.GetFiles(PS2Directory, "*.vag", SearchOption.AllDirectories);

            foreach (var sound in sounds)
            {
                _ = new VAGReader(sound);
            }
        }

        [TestMethod]
        public void VAGExportTest()
        {
            var outputpath = Path.Combine(TempDirectory, "hammer swing 1.wav");

            var reader = new VAGReader(Path.Combine(PS2Directory, "sounds\\weapons\\hammer swing 1.vag"));
            reader.Export(outputpath);

            Assert.IsTrue(File.Exists(outputpath));
        }

        [TestMethod]
        public void FNTReaderTest()
        {
            var fnts = Directory.GetFiles(BaseDirectory, "*.fnt", SearchOption.AllDirectories);

            foreach (var fnt in fnts)
            {
                // kanjii font is a different format
                if (fnt.Contains("kanjii"))
                    continue;

                _ = new FNTReader(fnt);
            }
        }

        [TestMethod]
        public void NIFReaderTest()
        {
            var nifs = Directory.GetFiles(BaseDirectory, "*.nif", SearchOption.AllDirectories);
            var ucfs = Directory.GetFiles(BaseDirectory, "*.ucf", SearchOption.AllDirectories);

            foreach (var nif in nifs)
                _ = new NIFReader(nif);

            foreach (var ucf in ucfs)
                _ = new NIFReader(ucf);
        }
    }
}