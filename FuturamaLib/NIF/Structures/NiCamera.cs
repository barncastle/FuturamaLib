using FuturamaLib.NIF.Enums;
using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiCamera : NiAVObject
    {
        public float FrustrumLeft;

        public float FrustrumRight;

        public float FrustrumTop;

        public float FrustrumBottom;

        public float FrustrumNear;

        public float FrustrumFar;

        public float ViewportLeft;

        public float ViewportRight;

        public float ViewportTop;

        public float ViewportBottom;

        public float LODAdjust;

        public NiRef<NiNode> UnknownLink;

        public float SpotAngle;

        public float SpotExponent;

        public NiCamera(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            FrustrumLeft = reader.ReadSingle();
            FrustrumRight = reader.ReadSingle();
            FrustrumTop = reader.ReadSingle();
            FrustrumBottom = reader.ReadSingle();
            FrustrumNear = reader.ReadSingle();
            FrustrumFar = reader.ReadSingle();
            ViewportLeft = reader.ReadSingle();
            ViewportRight = reader.ReadSingle();
            ViewportTop = reader.ReadSingle();
            ViewportBottom = reader.ReadSingle();
            LODAdjust = reader.ReadSingle();
            UnknownLink = new NiRef<NiNode>(reader);
            SpotAngle = reader.ReadSingle();

            if (File.Header.Version >= NifVersion.VER_4_2_1_0)
                SpotExponent = reader.ReadSingle();
        }
    }
}