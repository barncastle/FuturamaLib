namespace FuturamaLib.FNT
{
    public struct Header
    {
        public readonly ushort Width;
        public readonly ushort Height;

        /// <summary>
        /// Amount of space between top of one row and top of next row of printed text.
        /// </summary>
        public readonly ushort VerticalSpace;

        /// <summary>
        /// The width of a space in pixels.
        /// <para>
        /// It is also used as the width of ALL characters when the font system in game is forced into fixed width mode
        /// </para>
        /// </summary>
        public readonly ushort HorizontalSpace;

        public readonly ushort RowHeight;
    }
}