using System;
using Class;
using Photon.Pun;

public class RoomManager : SingleTon<RoomManager>
{
    private RoomData _roomData;

    public RoomData RoomData
    {
        get => _roomData;
    }

    public void CreateRoom(RoomData roomData)
    {
        _roomData = roomData;
        PhotonNetwork.Disconnect();
        SceneLoadManager.Instance.LoadScene(SceneType.RoomScene);
    }

    public void JoinRoom(RoomData roomData)
    {
        _roomData = roomData;
        //if (!PhotonNetwork.JoinRoom(roomName)) return;
        PhotonNetwork.Disconnect();
        SceneLoadManager.Instance.LoadScene(SceneType.RoomScene);
    }
}

public class RoomData
{
    public int roomNum; // OK
    public int purPlayerNum;
    public string roomTitle; // Ok
    public GameType? gameType;
    public int maxPlayer; // ok
}

