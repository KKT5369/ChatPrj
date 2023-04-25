using System;
using Class;
using Photon.Pun;

public class RoomManager : SingleTon<RoomManager>
{
    private RoomData _roomDatas;
    public Action<RoomData> createLobyRoom;

    public RoomData RoomDatas
    {
        get => _roomDatas;
    }

    public void CreateRoom(RoomData roomData)
    {
        _roomDatas = roomData;
        createLobyRoom.Invoke(roomData);
        PhotonNetwork.Disconnect();
        SceneLoadManager.Instance.LoadScene(new RoomScene());
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

