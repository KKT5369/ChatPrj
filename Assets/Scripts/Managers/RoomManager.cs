using System;
using System.Collections.Generic;
using Class;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class RoomManager : SingleTon<RoomManager>
{
    private List<RoomData> _roomDatas;
    public Action<RoomData> createLobyRoom;
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
        createLobyRoom.Invoke(roomData);
        
        // Debug.Log($"방 생성");
        // RoomOptions options = new RoomOptions();
        // options.MaxPlayers = (byte)roomData.maxPlayer;
        // options.IsVisible = true;
        // PhotonNetwork.NickName = roomData.HostName;
        // PhotonNetwork.CreateRoom(roomData.roomTitle, options,TypedLobby.Default);
        PhotonNetwork.Disconnect();
        SceneLoadManager.Instance.LoadScene(new RoomScene());
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
    public int roomNum; // OK
    public string HostName; // Ok
    public string roomTitle; // Ok
    public GameType? gameType;
    public int maxPlayer; // ok
}

