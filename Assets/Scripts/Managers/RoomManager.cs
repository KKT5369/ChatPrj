using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : SingleTon<RoomManager>
{
    private Stack<RoomData> _roomDatas;
    public Action<RoomData> action;

    private void Start()
    {
        _roomDatas = new Stack<RoomData>();
    }

    public Stack<RoomData> RoomDatas
    {
        get => _roomDatas;
    }

    public void CreateRoom(RoomData roomData)
    {
        _roomDatas.Push(roomData);
        action.Invoke(roomData);
    }
    
}

public class RoomData
{
    public string roomTitle;
    public GameType? gameType;
    public int userNumber;
}

