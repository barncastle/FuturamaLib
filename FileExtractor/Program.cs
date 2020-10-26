using FuturamaLib.Image;
using System;

namespace ImgExtractor
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length < 2 || string.IsNullOrWhiteSpace(args[0]))
            {
                Console.WriteLine("Arguments: <output directory> <.img path1> <.img path2> etc");
                Console.ReadLine();
                return;
            }

            for (var i = 1; i < args.Length; i++)
            {
                var imageReader = new ImageReader(args[i]);

                Console.WriteLine($"Loaded {args[i]} for {imageReader.RootDirectory.Platform}");
                Console.WriteLine();

                foreach (var entry in imageReader)
                {
                    Console.WriteLine("Extracting: " + entry.Value.ToString());
                    imageReader.ExtractFile(entry.Value, args[0]);
                }
            }
        }
    }
}