using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : SingleTon<RoomManager>
{
    private List<RoomData> _roomDatas;
    public Action<RoomData> action;
    public bool[] EmptyRooms;
    
    private void Start()
    {
        _roomDatas = new List<RoomData>();
        EmptyRooms = new bool[10];
        for (int i = 0; i < EmptyRooms.Length; i++)
        {
            EmptyRooms[i] = true;
        }
    }

    public List<RoomData> RoomDatas
    {
        get => _roomDatas;
    }

    public void CreateRoom(RoomData roomData)
    {
        _roomDatas.Add(roomData);
        action.Invoke(roomData);
    }
    
    

    public int GetEmptyRoom()
    {
        int result;
        for (int i = 0; i < EmptyRooms.Length; i++)
        {
            if (EmptyRooms[i])
            {
                result = i;
                EmptyRooms[i] = false;
                return result;
            }
        }
        return -1;
    }

    public RoomData GetRoomData(int RoomNum)
    {
        return _roomDatas[RoomNum];
    }
    
}

public class RoomData
{
    public int roomNum;
    public string HostName;
    public string roomTitle;
    public GameType? gameType;
    public int userNumber;
}

