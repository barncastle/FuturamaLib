using System.IO;
using System.Numerics;

namespace FuturamaLib.NIF.Structures
{
    public class NiParticleSystemController : NiTimeController
    {
        public float Speed;

        public float RandomSpeed;

        public float VerticalDirection;

        public float VerticalAngle;

        public float HorizontalDirection;

        public float HorizontalAngle;

        public Vector3 UnknownNormal;

        public Color4 UnknownColor;

        public float Size;

        public float EmitStartTime;

        public float EmitStopTime;

        public byte UnknownByte;

        public float EmitRate;

        public float Lifetime;

        public float LifetimeRandom;

        public ushort EmitFlags;

        public Vector3 StartRandom;

        public NiRef<NiObject> Emitter;

        public ushort NumParticles;

        public ushort NumValid;

        public Particle[] Particles;

        public NiRef<NiObject> UnknownRef;

        public NiRef<NiParticleModifier> ParticleExtra;

        public NiRef<NiObject> UnknownRef2;

        public byte Trailer;

        public NiParticleSystemController(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            Speed = reader.ReadSingle();
            RandomSpeed = reader.ReadSingle();
            VerticalDirection = reader.ReadSingle();
            VerticalAngle = reader.ReadSingle();
            HorizontalDirection = reader.ReadSingle();
            HorizontalAngle = reader.ReadSingle();
            UnknownNormal = reader.Read<Vector3>();
            UnknownColor = reader.Read<Color4>();
            Size = reader.ReadSingle();
            EmitStartTime = reader.ReadSingle();
            EmitStopTime = reader.ReadSingle();
            UnknownByte = reader.ReadByte();
            EmitRate = reader.ReadSingle();
            Lifetime = reader.ReadSingle();
            LifetimeRandom = reader.ReadSingle();
            EmitFlags = reader.ReadUInt16();
            StartRandom = reader.Read<Vector3>();
            Emitter = new NiRef<NiObject>(reader);

            reader.ReadUInt16();
            reader.ReadSingle();
            reader.ReadUInt32();
            reader.ReadUInt32();
            reader.ReadUInt16();

            NumParticles = reader.ReadUInt16();
            NumValid = reader.ReadUInt16();

            Particles = new Particle[NumParticles];
            for (var i = 0; i < NumParticles; i++)
                Particles[i] = new Particle(reader);

            UnknownRef = new NiRef<NiObject>(reader);

            ParticleExtra = new NiRef<NiParticleModifier>(reader);
            UnknownRef2 = new NiRef<NiObject>(reader);
            Trailer = reader.ReadByte();
        }
    }
}