using System.IO;

namespace FuturamaLib.NIF.Structures
{
    public class NiRoomGroup : NiNode
    {
        public NiRef<NiNode> Shell;
        public NiRef<NiRoom>[] Rooms;

        public NiRoomGroup(NIFReader file, BinaryReader reader) : base(file, reader)
        {
            Shell = new NiRef<NiNode>(reader);
            Rooms = new NiRef<NiRoom>[reader.ReadInt32()];
            for (var i = 0; i < Rooms.Length; i++)
                Rooms[i] = new NiRef<NiRoom>(reader);
        }
    }
}