using UnityEngine;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;

public enum EDirection
{
    None, Up, Down, Left, Right
}

public class Room
{
    private bool _visited = false;
    private bool _isMainPath = false;
    private Vector2Int _position;
    private Dictionary<EDirection, Room> _adjacentRoomList = new Dictionary<EDirection, Room>();
    private Dictionary<EDirection, Room> _childRoomList = new Dictionary<EDirection, Room>();

    public Room(int x, int y)
    {
        _position = new Vector2Int(x, y);
    }

    public bool IsVisit => _visited;
    
    public bool IsMainPath => _isMainPath;

    public void Visit() => _visited = true;

    public void Unvisit() => _visited = false;

    public string ToStringPosition() => _position.ToString();

    public void AddAdjacentRoom(EDirection direction, Room room)
    {
        _adjacentRoomList.Add(direction, room);
    }

    public void IncludePath(EDirection direction)
    {
        if (!_childRoomList.ContainsKey(direction))
        {
            _childRoomList.Add(direction, _adjacentRoomList[direction]);
        }
    }

    public void ExcludePath(EDirection direction)
    {
        if (_childRoomList.ContainsKey(direction))
        {
            _childRoomList.Remove(direction);
        }
    }

    public (EDirection direction, Room room) PickupRandomDirection()
    {
        List<EDirection> directionList = new List<EDirection>();
        foreach (var key in _adjacentRoomList.Keys)
        {
            if (!_adjacentRoomList[key]._visited)
            {
                directionList.Add(key);
            }
        }

        if (directionList.Count == 0)
        {
            return (EDirection.None, null);
        }
        EDirection direction = directionList[Random.Range(0, directionList.Count)];
        return (direction, _adjacentRoomList[direction]);
    }

    public Dictionary<EDirection, Room> ChildRoomList => _childRoomList;

    public Room GetChildRoom(EDirection direction)
    {
        if (!_childRoomList.ContainsKey(direction))
        {
            return null;
        }
        return _childRoomList[direction];
    }
}