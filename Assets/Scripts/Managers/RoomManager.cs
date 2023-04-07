using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : SingleTon<RoomManager>
{
    private Stack<RoomData> _roomDatas;
    
    public Stack<RoomData> RoomDatas
    {
        get => _roomDatas;
    }

    public void CreateRoom(RoomData roomData)
    {
        _roomDatas.Push(roomData);
    }
    
}

public class RoomData
{
    public string roomTitle;
    public GameType? gameType;
    public int userNumber;
}

