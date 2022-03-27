
using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace TH01.MazeOfRooms;

public enum Direction
{
    NORTH, SOUTH, EAST, WEST
}

// Time to completion ~45 mintues to 1HR - unfortunately I had a totally unexepcted urgent
// production issue flare up in the middle of doing this so it's tough to get a good read
// on how long it really took)
public class Maze
{
    public Dictionary<string, Room> Rooms = new();

    // Get or create a new room and add it to the stored hashset of rooms
    public Room GetOrCreateRoom(string name)
    {
        if (Rooms.ContainsKey(name))
        {
            return Rooms[name];
        }
        Room room = new Room { Name = name };
        Rooms.Add(name, room);
        return room;
    }

    public void ConnectRoom(string from, string to, Direction direction)
    {
        Room room = GetOrCreateRoom(from);
        room.Doors[(int)direction] = GetOrCreateRoom(to);
    }
}

public class Room
{
    public string? Name { get; set; }
    public Room[] Doors { get; set; }
    HashSet<Room> _visited;
    Queue<Room> _check;

    public Room()
    {
        Doors = new Room[4];
        _visited = new();
        _check = new();
    }

    private void checkDoors(Room[] doors)
    {
        foreach (Room door in doors)
        {
            if (door != null && !_visited.Contains(door))
            {
                _check.Enqueue(door);
            }
        }
    }

    public bool PathExistsTo(string endingRoomName)
    {
        _visited = new();
        _check = new();
        _visited.Add(this);
        checkDoors(Doors);
        while (_check.Count > 0)
        {
            Room room = _check.Dequeue();
            if (room.Name == endingRoomName)
            {
                return true;
            }
            _visited.Add(room);
            checkDoors(room.Doors);
        }
        return false;
    }
}

public class MazeOfRoomsTest
{
    [Test]
    [TestCase("A,B,C,D", "A|0|D,B|1|C", "C", "D", false)]
    [TestCase("A,B,C,D", "A|0|D,B|1|C", "A", "D", true)]
    public void TestConnections(string Rooms, string Connections, string From, string To, bool expect)
    {
        Maze m = new Maze();
        foreach (string s in Rooms.Split(","))
        {
            m.GetOrCreateRoom(s);
        }

        foreach (string connection in Connections.Split(","))
        {
            string[] c = connection.Split("|");
            m.ConnectRoom(c[0], c[2], (Direction)Int32.Parse(c[1]));
        }

        Room CheckPathFrom = m.GetOrCreateRoom(From);
        bool result = CheckPathFrom.PathExistsTo(To);
        Assert.AreEqual(result, expect);
    }
}
