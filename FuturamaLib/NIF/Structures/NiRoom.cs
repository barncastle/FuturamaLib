using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiRoom : NiNode
    {
        public NiRef<NiWall>[] Walls;
        public NiRef<NiPortal>[] InteriorPortals;
        public NiRef<NiPortal>[] ExteriorPortals;
        public NiRef<NiAVObject>[] Fixtures;

        public NiRoom(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            Walls = new NiRef<NiWall>[reader.ReadInt32()];
            for (var i = 0; i < Walls.Length; i++)
                Walls[i] = new NiRef<NiWall>(reader);

            InteriorPortals = new NiRef<NiPortal>[reader.ReadInt32()];
            for (var i = 0; i < InteriorPortals.Length; i++)
                InteriorPortals[i] = new NiRef<NiPortal>(reader);

            ExteriorPortals = new NiRef<NiPortal>[reader.ReadInt32()];
            for (var i = 0; i < ExteriorPortals.Length; i++)
                ExteriorPortals[i] = new NiRef<NiPortal>(reader);

            Fixtures = new NiRef<NiAVObject>[reader.ReadInt32()];
            for (var i = 0; i < Fixtures.Length; i++)
                Fixtures[i] = new NiRef<NiAVObject>(reader);
        }
    }
}