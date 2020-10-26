using FuturamaLib.NIF.Enums;
using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiKeyframeData : NiObject
    {
        public KeyType KeyType;

        public QuatKey[] QuaternionKeys;

        public float UnknownFloat;

        public KeyGroup<FloatKey>[] Rotations;

        public KeyGroup<VecKey> Translations;

        public KeyGroup<FloatKey> Scales;

        public NiKeyframeData(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            var count = reader.ReadUInt32();

            if (count != 0u)
                KeyType = (KeyType)reader.ReadUInt32();

            if (KeyType == KeyType.XYZ_ROTATION_KEY)
            {
                UnknownFloat = reader.ReadSingle();

                Rotations = new KeyGroup<FloatKey>[]
                {
                    new KeyGroup<FloatKey>(reader),
                    new KeyGroup<FloatKey>(reader),
                    new KeyGroup<FloatKey>(reader)
                };
            }
            else
            {
                QuaternionKeys = new QuatKey[count];
                for (var i = 0; i < QuaternionKeys.Length; i++)
                    QuaternionKeys[i] = new QuatKey(reader, KeyType);
            }

            Translations = new KeyGroup<VecKey>(reader);
            Scales = new KeyGroup<FloatKey>(reader);
        }
    }
}