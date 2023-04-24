using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class NetWorkManager : MonoBehaviourPunCallbacks
{
    private readonly string _version = "1.0f";
    private static NetWorkManager _instance;

    private void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = _version;
        Connect();
    }

    public void Connect()
    {
        PhotonNetwork.ConnectUsingSettings();
        DontDestroyOnLoad(gameObject);
    }
    
    // 포톤 서버 연결시 실행
    public override void OnConnectedToMaster()
    {
        print("접속성공.");
    }

    // 로비 입장시 실행
    public override void OnJoinedLobby()
    {
        print($"로비입장.");
    }
    
    public void OnCreatedRoom(RoomData roomData)
    {
        Debug.Log($"방 생성");
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = (byte)roomData.maxPlayer;
        options.IsVisible = true;
        PhotonNetwork.NickName = roomData.HostName;
        PhotonNetwork.JoinOrCreateRoom(roomData.roomTitle, options,TypedLobby.Default);
    }

    public override void OnCreatedRoom()
    {
        print("방 만들기 완료.");
    }
    
    public override void OnJoinedRoom()
    {
        print("방 참가 완료.");
    }
    
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        print("방 만들기 실패.");
    }
    
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        print("방 참가 실패.");
    }
    
    public override void OnDisconnected(DisconnectCause cause)
    {
        print("연결 끊김.");
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        base.OnRoomListUpdate(roomList);
    }

    public override void OnLeftRoom()
    {
        Debug.Log("방 나감");
    }
}
