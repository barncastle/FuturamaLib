namespace FuturamaLib.NIF.Structures
{
    public interface INiRef
    {
        uint RefId { get; }
        bool IsValid { get; }

        void SetRef(NIFReader file);
    }
}