using ExitGames.Client.Photon;
using JetBrains.Annotations;
using Photon.Pun;

public class RoomManager : SingleTon<RoomManager>
{
    private RoomData _roomData;

    public RoomData RoomData
    {
        get => _roomData;
    }

    public void CreateOrJoinRoom(RoomData roomData)
    {
        _roomData = roomData;
        NetWorkManager.Instance.CreateOrJoinRoom();
        SceneLoadManager.Instance.LoadScene(SceneType.RoomScene);
    }

    public void RandomRoom()
    {
        NetWorkManager.Instance.RandomJoinRoom();
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

