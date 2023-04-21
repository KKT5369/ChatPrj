using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RoomManager : SingleTon<RoomManager>
{
    private List<RoomData> _roomDatas;
    public Action<RoomData> action;
    public bool[] emptyRooms;
    
    private void Start()
    {
        _roomDatas = new List<RoomData>();
        emptyRooms = new bool[10];
        for (int i = 0; i < emptyRooms.Length; i++)
        {
            emptyRooms[i] = true;
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
        // PhotonManager.Instance.OnCreatedRoom();
    }
    
    

    public int GetEmptyRoom()
    {
        int result;
        for (int i = 0; i < emptyRooms.Length; i++)
        {
            if (emptyRooms[i])
            {
                result = i;
                emptyRooms[i] = false;
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
    public int maxPlayer;
}

