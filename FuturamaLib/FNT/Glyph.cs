namespace FuturamaLib.FNT
{
    public struct Glyph
    {
        public readonly short Char;
        public readonly short X;
        public readonly short Y;
        public readonly short Width;
        public readonly short Height;

        public override string ToString()
        {
            if (Char < 0x20 || Char >= 0x7F)
                return $"\\u{Char:X4}";
            else
                return new string((char)Char, 1);
        }
    }
}