using UnityEngine;
using System.Collections.Generic;

public class Field
{
    private Room[,] _field = new Room[4, 4];
    private Room _startRoom;
    private Room _exitRoom;

    public Field()
    {
        for (int y = 0; y < 4; y++)
        {
            for (int x = 0; x < 4; x++)
            {
                _field[y, x] = new Room(x, y);
            }
        }

        for (int y = 0; y < 4; y++)
        {
            for (int x = 0; x < 4; x++)
            {
                if (x > 0)
                {
                    _field[y, x].AddAdjacentRoom(EDirection.Left, _field[y, x - 1]);
                }
                if (x < 3)
                {
                    _field[y, x].AddAdjacentRoom(EDirection.Right, _field[y, x + 1]);
                }
                if (y > 0)
                {
                    _field[y, x].AddAdjacentRoom(EDirection.Up, _field[y - 1, x]);
                }
                if (y < 3)
                {
                    _field[y, x].AddAdjacentRoom(EDirection.Down, _field[y + 1, x]);
                }
            }
        }
    }

    public void SetStartRoom()
    {
        int x = Random.Range(0, 4);
        int y = Random.Range(0, 4);
        _startRoom = _field[y, x];
    }

    public void SetExitRoom(uint pathCount = 6)
    {
        Stack<(EDirection direction, Room room)> roomHistory = new Stack<(EDirection direction, Room room)>();
        (EDirection direction, Room room) current = (EDirection.None, _startRoom);

        while (pathCount > 0)
        {
            if (current.room.IsVisit)
            {
                var before = roomHistory.Pop();
                before.room.ExcludePath(before.direction);
                current = before;
                pathCount++;
            }

            var next = current.room.PickupRandomDirection();
            
            if (next.room == null)
            {
                var before = roomHistory.Pop();
                before.room.ExcludePath(before.direction);
                current = before;
                pathCount++;
            }
            else
            {
                current.room.Visit();
                roomHistory.Push(current);
                current.room.IncludePath(next.direction);
                current = next;
                pathCount--;
            }
        }

        _exitRoom = current.room;
    }

    public void MakeSubPath()
    {
        Room room = _startRoom;

        while (room != null)
        {
            if (room == _exitRoom)
            {
                break;
            }
            var children = room.ChildRoomList;
            if (children.Count == 0)
            {
                // 랜덤으로 경로 설정
            }
            else
            {
                foreach (var child in children.Values)
                {
                    room = child;
                    break;
                }
            }
        }
    }

    public void ShowMainPath()
    {
        Room room = _startRoom;

        while (room != null)
        {
            Debug.Log(room.ToStringPosition());

            if (room == _exitRoom)
            {
                break;
            }
            var children = room.ChildRoomList;
            if (children.Count == 0)
            {
                break;
            }
            foreach (var child in children.Values)
            {
                room = child;
                break;
            }
        }
    }
}