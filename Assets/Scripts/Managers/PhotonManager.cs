using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    private readonly string _version = "1.0f";

    private void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = _version;
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnCreatedRoom()
    {
        RoomOptions options = new();
        options.MaxPlayers = 5;
        PhotonNetwork.CreateRoom("test1", options);
    }

    public void CreateRoom(RoomData roomData)
    {
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 5;
        PhotonNetwork.CreateRoom(roomData.roomTitle, options, TypedLobby.Default);
    }

    public void JoinRoom(RoomData roomData)
    {
        PhotonNetwork.JoinRoom(roomData.roomTitle);
    }

    public override void OnJoinedRoom()
    {
        print($"OnJoineRoom 실행");
    }

    public override void OnConnectedToMaster()
    {
        print("접속성공.");
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 5;
        PhotonNetwork.LocalPlayer.NickName = "testNicName";
        PhotonNetwork.CreateRoom("test1", options);
    }

    public override void OnJoinedLobby()
    {
        print($"로비입장.");
    }
}
