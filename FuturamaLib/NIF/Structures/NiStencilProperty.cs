using FuturamaLib.NIF.Enums;
using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiStencilProperty : NiProperty
    {
        public ushort Flags;

        public bool IsStencilEnabled;

        public StencilCompareMode StencilFunction;

        public uint StencilRef;

        public uint StencilMask;

        public StencilAction FailAction;

        public StencilAction ZFailAction;

        public StencilAction PassAction;

        public FaceDrawMode FaceDrawMode;

        public NiStencilProperty(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            Flags = reader.ReadUInt16();
            IsStencilEnabled = reader.ReadBoolean();
            StencilFunction = (StencilCompareMode)reader.ReadUInt32();
            StencilRef = reader.ReadUInt32();
            StencilMask = reader.ReadUInt32();
            FailAction = (StencilAction)reader.ReadUInt32();
            ZFailAction = (StencilAction)reader.ReadUInt32();
            PassAction = (StencilAction)reader.ReadUInt32();
            FaceDrawMode = (FaceDrawMode)reader.ReadUInt32();
        }
    }
}